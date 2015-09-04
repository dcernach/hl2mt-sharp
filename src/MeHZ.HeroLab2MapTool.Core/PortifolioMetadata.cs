using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core.Models;

namespace MeHZ.HeroLab2MapTool.Core {
    public class PortifolioMetadata {
        public PortifolioMetadata(HerolabCharacter entry) {
            HeroLabCharacter = entry;
        }

        public string           PortifolioFile   { get; set; }
        public string           PortraitImage    { get; set; }
        public string           PogImage         { get; set; }
        public bool             GenerateToken    { get; set; }
        public HerolabCharacter HeroLabCharacter { get; internal set; }
    }
}
