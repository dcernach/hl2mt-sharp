using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MeHZ.HeroLab2MapTool.Core.Models {
    public class HerolabCharacter {
        public string           Name            { get; set; }

        public string           Summary         { get; set; }

        [JsonIgnore]
        public string           FilePath        { get; set; }

        [JsonIgnore]
        public bool             IsMinion        { get; set; }

        [JsonIgnore]
        public string           TextStatblock   { get; set; }

        [JsonIgnore]
        public string           HtmlStatblock   { get; set; }

        [JsonIgnore]
        public XElement         XmlStatblock    { get; set; }

        [JsonIgnore]
        public HerolabCharacter Owner           { get; set; }
    }
}
