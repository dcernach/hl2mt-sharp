using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
using MeHZ.HeroLab2MapTool.Core.Models;
using MeHZ.HeroLab2MapTool.Core.Extensions;
using System.Security.Cryptography;
using System.Xml;

namespace MeHZ.HeroLab2MapTool.Core {
    public class PortifolioParser {


        /// <summary>
        /// Returns an IEnumerable containing all characters found in HerolLab portifolio.
        /// </summary>
        public IEnumerable<HerolabCharacter> Characters {
            get;
            private set;
        }


        /// <summary>
        /// Loads and parses all required information of specified Herolab portifolio.
        /// </summary>
        /// <param name="path">Full path to HeroLab portifolio (.por) file.</param>
        public void Load(string path) {
            var fileStream = new FileStream(path, FileMode.Open);
            var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Read);
            var indexEntry = zipArchive.GetEntry("index.xml");
            var gzipStream = indexEntry.OpenAsMemoryStream();

            var rootElm = XElement.Load(gzipStream);
            var charElms = rootElm.Elements("characters").Elements("character").ToList();
            var portEntries = new List<HerolabCharacter>();

            foreach (var item in charElms) {
                var heroStatBlocks = item.Elements("statblocks").Elements("statblock");

                var zipEntries = heroStatBlocks.Select(e => new {
                    Format  = e.Attribute("format").Value,
                    Entry   = string.Format("{0}/{1}", e.Attribute("folder").Value, e.Attribute("filename").Value)
                }).ToDictionary(t => t.Format, t => t.Entry);


                // Load required character information
                var heroStats           = new HerolabCharacter();
                heroStats.Name          = item.Attribute("name").Value;
                heroStats.Summary       = item.Attribute("summary").Value;
                heroStats.FilePath      = path;
                heroStats.TextStatblock = zipArchive.GetEntryAsString(zipEntries["text"]);
                heroStats.HtmlStatblock = zipArchive.GetEntryAsString(zipEntries["html"]);

                var xmlStatBlock = XElement.Load(zipArchive.GetEntryAsStream(zipEntries["xml"]));
                var currHero = xmlStatBlock.Descendants("character")
                    .Where(d => d.Attribute("name").Value == heroStats.Name).FirstOrDefault();


                // Copy Hero xml statblock without <minions> element. It's just to avoid element cluttering.
                currHero = new XElement(currHero);
                currHero.Element("minions").Descendants().Remove();
                heroStats.XmlStatblock = currHero;
                portEntries.Add(heroStats);


                // Load Minions character information for current Hero.
                var minions = item.Elements("minions").Elements("character");

                foreach (var minion in minions) {
                    var minionStatBlocks = minion.Elements("statblocks").Elements("statblock");

                    zipEntries = minionStatBlocks.Select(e => new {
                        Format  = e.Attribute("format").Value,
                        Entry   = string.Format("{0}/{1}", e.Attribute("folder").Value, e.Attribute("filename").Value)
                    }).ToDictionary(t => t.Format, t => t.Entry);

                    var minionStats = new HerolabCharacter();
                    minionStats.Name          = minion.Attribute("name").Value;
                    minionStats.Summary       = minion.Attribute("summary").Value;
                    minionStats.FilePath      = path;
                    minionStats.Owner         = heroStats;
                    minionStats.IsMinion      = true;
                    minionStats.TextStatblock = zipArchive.GetEntryAsString(zipEntries["text"]);
                    minionStats.HtmlStatblock = zipArchive.GetEntryAsString(zipEntries["html"]);

                    var currMinion = xmlStatBlock.Descendants("character")
                        .Where(d => d.Attribute("name").Value == minionStats.Name).FirstOrDefault();

                    minionStats.XmlStatblock = currMinion;
                    portEntries.Add(minionStats);
                }
            }

            gzipStream.Dispose();
            fileStream.Dispose();
            zipArchive.Dispose();

            Characters = portEntries;
        }
    }
}
