using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core;
using NUnit.Framework;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace MeHZ.HeroLab2MapTool.Test {

    [TestFixture]
    public class DirectoryWalkerTest {
        Stopwatch stopWatch = new Stopwatch();


        [SetUp]
        public void SetUp() {
        }


        [Test]
        public void try_process_directory_files() {
            var walker = new DirectoryWalker(DataDirectory.ROOT_FOLDER);
            walker.Process();

            var list = walker.Files.OrderBy(e => e.FileType).ThenBy(e => e.FileName).ToList();
            var expected = 24;
            var actual = list.Count();

            Assert.AreEqual(expected, actual);

            stopWatch.Start();
            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(DataDirectory.TEMPORARY_FOLDER + "\\file_list.json", json);
            stopWatch.Stop();

            Console.WriteLine("A: Elapsed={0}", stopWatch.Elapsed);
        }


        [Test]
        public void exec_directory_walker_processing() {
            var files = new List<FileEntryMetadata>();
            var path = @"C:\Users\p017058\Copy\Roleplay\Pathfinder\Legacy of Fire";

            var walker = new DirectoryWalker(path);
            //var file = File.CreateText(Path.Combine(DataDirectory.ROOT_FOLDER, "files.txt"));

            walker.FileFound += (sender, e) => {
                //file.WriteLine(e.FilePath);
                //Console.WriteLine(e.FilePath);

                var x = new FileEntryMetadata {
                    Directory   = Path.GetDirectoryName(e.FilePath),
                    FileName    = Path.GetFileName(e.FilePath),
                    MatchLength = 0
                };

                files.Add(x);
            };
            

            stopWatch.Start();
            walker.Process();
            stopWatch.Stop();

            //file.Close();

            Console.WriteLine("B: Elapsed={0}", stopWatch.Elapsed);
        }


        [Test]
        public void match_names_in_files() {
            var files = new List<FileEntryMetadata>();
            var path = @"C:\Users\p017058\Copy\Roleplay\Pathfinder\Legacy of Fire";
            var walker = new DirectoryWalker(path);

            walker.FileFound += (sender, e) => {
                var x = new FileEntryMetadata {
                    Directory = Path.GetDirectoryName(e.FilePath),
                    FileName = Path.GetFileName(e.FilePath),
                    MatchLength = 0
                };

                files.Add(x);
            };

            walker.Process();

            var charName = "Almah Roveshki";
            var terms = charName.Split(' ');
            var pattern = String.Join("|", terms);

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

            var matches = files.Select(e => new FileEntryMetadata {
                Directory = e.Directory,
                FileName = e.FileName,
                MatchLength = e.MatchLength = regex.Matches(e.FileName).Count
            })
            .Where(e => e.MatchLength > 0)
            .OrderByDescending(e => e.MatchLength);
        }
    }
}
