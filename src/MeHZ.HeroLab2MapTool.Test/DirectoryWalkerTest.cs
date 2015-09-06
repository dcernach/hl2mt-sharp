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

            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(DataDirectory.TEMPORARY_FOLDER + "\\file_list.json", json);
        }


        [Test]
        public void try_process__portifolios_and_portraits_and_pogs__in_diferent_directories() {
            var portifolioPath = DataDirectory.PORTIFOLIO_FOLDER;
            var portraitPath = DataDirectory.PORTRAIT_FOLDER;
            var pogsPath = DataDirectory.POG_FOLDER;

            var portifolioWalker = new DirectoryWalker(portifolioPath, FileEntryType.Portifolio);
            var portraitWalker   = new DirectoryWalker(portraitPath, FileEntryType.Portrait);
            var pogsWalker       = new DirectoryWalker(pogsPath, FileEntryType.Pog);

            portifolioWalker.Process();
            portraitWalker.Process();
            pogsWalker.Process();

            var totalPortifoliosCount = portifolioWalker.Files.Count();
            var totalPortraitsCount = portraitWalker.Files.Count();
            var totalPogsCount = pogsWalker.Files.Count();

            Assert.AreEqual(6, totalPortifoliosCount, "Total Portifolios");
            Assert.AreEqual(9, totalPortraitsCount, "Total Portraits");
            Assert.AreEqual(9, totalPogsCount, "Total POGs");
        }


        [Test]
        public void exec_directory_walker_processing() {
            var files = new List<DirectoryWalkerFile>();
            var path = @"D:\Users\dandrade\Copy\Roleplay\Pathfinder\Legacy of Fire";

            var walker = new DirectoryWalker(path);

            walker.FileFound += (sender, e) => {
                var x = new DirectoryWalkerFile {
                    Directory   = Path.GetDirectoryName(e.FilePath),
                    FileName    = Path.GetFileName(e.FilePath),
                    MatchLength = 0
                };

                files.Add(x);
            };
            
            walker.Process();
        }


        [Test]
        public void match_names_in_files() {
            var files = new List<DirectoryWalkerFile>();
            var path = @"D:\Users\dandrade\Copy\Roleplay\Pathfinder\Legacy of Fire";
            var walker = new DirectoryWalker(path);

            walker.FileFound += (sender, e) => {
                var x = new DirectoryWalkerFile {
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

            var matches = files.Select(e => new DirectoryWalkerFile {
                Directory = e.Directory,
                FileName = e.FileName,
                MatchLength = e.MatchLength = regex.Matches(e.FileName).Count
            })
            .Where(e => e.MatchLength > 0)
            .OrderByDescending(e => e.MatchLength);
        }
    }
}
