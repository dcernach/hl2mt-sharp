using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeHZ.HeroLab2MapTool.Core.Models {
    public class PortifolioEntry {
        public string           Name            { get; set; }
        public string           Summary         { get; set; }
        public bool             IsMinion        { get; set; }
        public string           TextStatblock   { get; set; }
        public string           HtmlStatblock   { get; set; }
        public XElement         XmlStatblock    { get; set; }
        public PortifolioEntry   Owner           { get; set; }
    }
}
