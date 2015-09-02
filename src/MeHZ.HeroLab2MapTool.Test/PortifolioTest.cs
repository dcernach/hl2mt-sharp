using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MeHZ.HeroLab2MapTool.Core;
using System.IO;

namespace MeHZ.HeroLab2MapTool.Test {

    [TestFixture]
    public class PortifolioTest {
        private string input_folder;
        private string output_folder;
        private string pog_folder;

        [SetUp]
        public void SetUp() {
            input_folder = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "test_data");
            output_folder = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "test_data");
            pog_folder = Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "..", "test_data");
        }


        [Test]
        public void try_open_hl_portifolio() {
            var path = Path.Combine(input_folder, "Merith-and-Zell.por");
            var port = new Portifolio();
            port.Load(path);

            var expected = 4;
            var actual = port.PortifolioEntries.Count();

            Assert.AreEqual(expected, actual);

            var chars = port.PortifolioEntries.ToList();
            Assert.AreEqual(chars[0].XmlStatblock.Attribute("name").Value, "Zell Nastraniel");
            Assert.AreEqual(chars[1].XmlStatblock.Attribute("name").Value, "Luna");
            Assert.AreEqual(chars[2].XmlStatblock.Attribute("name").Value, "Merith (Mer-et-Seger)");
            Assert.AreEqual(chars[3].XmlStatblock.Attribute("name").Value, "Nakht");
        }
    }
}
