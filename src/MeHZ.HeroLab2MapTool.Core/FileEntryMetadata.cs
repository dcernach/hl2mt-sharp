using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Core {

    public class FileEntryMetadata {
        public string        Directory      { get; set; }
        public string        FileName       { get; set; }
        public string        Extension      { get; set; }
        public int           MatchLength    { get; set; }
        public FileEntryType FileType       { get; set; }
    }
}
