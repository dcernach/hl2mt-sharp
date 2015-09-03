using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core.Models;

namespace MeHZ.HeroLab2MapTool.Core {
    public class PortifolioMetadata {
        public PortifolioMetadata(PortifolioEntry entry) {
            Portifolio = entry;
        }

        public PortifolioEntry  Portifolio      { get; internal set; }
        public Object           PortifolioFile  { get; internal set; }
        public Object           PortraitImage   { get; internal set; }
        public Object           PogImage        { get; internal set; }
    }
}
