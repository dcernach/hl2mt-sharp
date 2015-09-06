using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core;
using NUnit.Framework;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace MeHZ.HeroLab2MapTool.Test {
    [TestFixture]
    public class PortifolioLoaderTest {
        private Stopwatch stopWatch = new Stopwatch();


        [SetUp]
        public void SetUp() {
        }


        [Test]
        public void try_load__portifolios_and_portraits_and_pogs__from_root_dir() {
            var loader = new PortifolioLoader();
            loader.ProcessDirectory(DataDirectory.ROOT_FOLDER);
        }


        [Test]
        public void try_load__portifolios_and_portraits_and_pogs__in_diferent_directories() {
            var portifolioPath = DataDirectory.PORTIFOLIO_FOLDER;
            var portraitPath = DataDirectory.PORTRAIT_FOLDER;
            var pogsPath = DataDirectory.POG_FOLDER;
                       
            var loader = new PortifolioLoader();
            loader.ProcessDirectory(portifolioPath, portraitPath, pogsPath);

            var list = loader.Portifolios;

            Assert.AreEqual(13, list.Count());

            var json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(DataDirectory.TEMPORARY_FOLDER + "\\try_load__portifolios_and_portraits_and_pogs__in_diferent_directories.json", json);
        }
    }
}
