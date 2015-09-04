using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core;
using NUnit.Framework;
using System.Diagnostics;

namespace MeHZ.HeroLab2MapTool.Test {
    [TestFixture]
    public class ConfigurationManagerTest {
        private Stopwatch stopWatch = new Stopwatch();


        [Test]
        public void test_if_I_can_create_and_read_default_settings() {
            ConfigurationManager.Reset();
            var expected = "C:\\Workspace\\work\\dot.net\\hl2mt-sharp\\test_data\\tokens";
            var actual = ConfigurationManager.Settings.General.OutputFolder;

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void test_if_I_can_change_property_and_save() {
            ConfigurationManager.Settings.CampaignProperties.TokenType = "PathfinderNext";
            ConfigurationManager.Save();
            ConfigurationManager.Read();

            var expected = "PathfinderNext";
            var actual = ConfigurationManager.Settings.CampaignProperties.TokenType;

            Assert.AreEqual(expected, actual);

            ConfigurationManager.Reset();
        }


        [Test]
        public void test_if_I_can_export_settings() {
            var output = Path.Combine(DataDirectory.TEMPORARY_FOLDER, "hl2mt-export.conf");

            ConfigurationManager.Settings.General.OutputFolder = Environment.CurrentDirectory;
            ConfigurationManager.Export(output);

            var condition = File.Exists(output);

            Assert.IsTrue(condition);
        }


        [Test]
        public void test_if_I_can_import_settings() {
            var input = Path.Combine(DataDirectory.TEMPORARY_FOLDER, "hl2mt-export.conf");

            ConfigurationManager.Reset();
            ConfigurationManager.Import(input);

            var expected = Environment.CurrentDirectory;
            var actual = ConfigurationManager.Settings.General.OutputFolder;

            Assert.AreEqual(expected, actual);
        }
    }
}
