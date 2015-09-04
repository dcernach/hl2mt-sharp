using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core.Models;

namespace MeHZ.HeroLab2MapTool.Core {

    public class PortifolioLoader {
        private List<DirectoryWalkerFile>   directoryWalkerFiles;
        private List<HerolabCharacter>      heroLabCharacters;
        private List<PortifolioMetadata>    m_portifolios;


        public PortifolioLoader() {
            directoryWalkerFiles = new List<DirectoryWalkerFile>();
            heroLabCharacters = new List<HerolabCharacter>();
            m_portifolios = new List<PortifolioMetadata>();
        }


        public IEnumerable<PortifolioMetadata> Portifolios {
            get {
                return m_portifolios;
            }
        }


        public void ProcessDirectory(string path) {
            var directoryWalker = new DirectoryWalker(path);
            directoryWalker.Process();
            directoryWalkerFiles = directoryWalker.Files.ToList();

            var portifolioFiles  = directoryWalkerFiles.Where(e => e.FileType == FileEntryType.Portifolio);
            var portifolioParser = new PortifolioParser();

            foreach(var portifolio in portifolioFiles) {
                portifolioParser.Load(portifolio.FullPath);
                heroLabCharacters.AddRange(portifolioParser.Characters);
            }

            CreatePortifoliosMetadata();
        }


        public void ProcessDirectory(string portifoliosPath, string portraitsPath, string pogsPath) {
            directoryWalkerFiles.Clear();

            var portifoliosWalker = new DirectoryWalker(portifoliosPath, FileEntryType.Portifolio);
            portifoliosWalker.Process();
            directoryWalkerFiles.AddRange(portifoliosWalker.Files.ToList());

            var portraitsWalker = new DirectoryWalker(portraitsPath, FileEntryType.Portrait);
            portraitsWalker.Process();
            directoryWalkerFiles.AddRange(portraitsWalker.Files.ToList());

            var pogsWalker = new DirectoryWalker(pogsPath, FileEntryType.Pog);
            pogsWalker.Process();
            directoryWalkerFiles.AddRange(pogsWalker.Files.ToList());

            var portifolioParser = new PortifolioParser();

            foreach (var portifolio in portifoliosWalker.Files) {
                portifolioParser.Load(portifolio.FullPath);
                heroLabCharacters.AddRange(portifolioParser.Characters);
            }

            CreatePortifoliosMetadata();
        }


        private Regex BuildPogRegex(HerolabCharacter entry) {
            var terms = CreateSearchKeywords(entry.Name);
            var pattern = string.Format("pog|token|{0}", string.Join("|", terms));
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            return regex;
        }


        private Regex BuildPortraitRegex(HerolabCharacter entry) {
            var terms = CreateSearchKeywords(entry.Name);
            var pattern = string.Format("portrait|{0}", string.Join("|", terms));
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            return regex;
        }


        private void CreatePortifoliosMetadata() {
            foreach (var entry in heroLabCharacters) {
                var portraitRegex = BuildPortraitRegex(entry);
                var portraitFile = GetBestFileMatch(portraitRegex);

                var pogRegex = BuildPogRegex(entry);
                var pogFile  = GetBestFileMatch(pogRegex);

                if (portraitFile != null) {
                    portraitFile.FileType = FileEntryType.Portrait;
                }

                if (pogFile != null) {
                    pogFile.FileType = FileEntryType.Pog; 
                }

                var portifolio = new PortifolioMetadata(entry);
                portifolio.PortifolioFile = entry.FilePath;
                portifolio.PortraitImage = portraitFile.FullPath;
                portifolio.PogImage = pogFile.FullPath;
                portifolio.GenerateToken = true;
                m_portifolios.Add(portifolio);
            }
        }


        private string[] CreateSearchKeywords(string searchPhrase) {
            if (string.IsNullOrWhiteSpace(searchPhrase)) {
                throw new ArgumentNullException("searchPhrase");
            }

            var regexSanitize = new Regex(@"[^\w-]");
            var regexNormalize = new Regex(@"\s+");

            var result = regexSanitize.Replace(searchPhrase, " ");
            result = regexNormalize.Replace(result, " ");
            result = result.Trim();

            var terms = result.Split(' ');

            return terms;
        }


        private DirectoryWalkerFile GetBestFileMatch(Regex regex) {
            return directoryWalkerFiles
                .Where(e => e.FileType != FileEntryType.Portifolio)
                .Select(x => {
                    var pattern = string.Join("|", CreateSearchKeywords(x.FullPath));
                    x.MatchLength = regex.Matches(pattern).Count;
                    return x;
                }).Where(e => e.MatchLength > 0)
                .OrderByDescending(e => e.MatchLength)
                .FirstOrDefault();
        }
    }
}
