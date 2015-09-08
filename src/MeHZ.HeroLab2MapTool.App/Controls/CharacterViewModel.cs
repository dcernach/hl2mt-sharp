using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MeHZ.HeroLab2MapTool.Core;

namespace MeHZ.HeroLab2MapTool.App.Controls {
    public class CharacterViewModel {
        public ICollectionView Characters { get; private set; }

        public CharacterViewModel() {
            //var chars = new List<CharacterModel> {
            //    new CharacterModel {
            //        Name          = "Kerish en-Salam",
            //        Portifolio    = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\Kerish.por",
            //        PogImage      = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\pogs\Kerish.png",
            //        PortraitImage = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\portraits\Kerish.png" },

            //    new CharacterModel {
            //        Name          = "Zell Nastraniel",
            //        Portifolio    = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\Zell.por",
            //        PogImage      = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\pogs\Zell.png",
            //        PortraitImage = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\portraits\Zell.png" },

            //    new CharacterModel {
            //        Name          = "Grainne Mahooly",
            //        Portifolio    = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\Grainne.por",
            //        PogImage      = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\pogs\Grainne.png",
            //        PortraitImage = @"C:\Workspace\dot.net\hl2mt-sharp\test_data\portraits\Grainne.png" }
            //};

            //Characters = CollectionViewSource.GetDefaultView(chars);
        }

        public void ProcessFiles() {
            
            var loader = new PortifolioLoader();
            if (ConfigurationManager.Settings.General.InputFolderScan) {
                loader.ProcessDirectory(ConfigurationManager.Settings.General.InputFolder);
            } else {

                loader.ProcessDirectory(ConfigurationManager.Settings.General.InputFolder,
                    ConfigurationManager.Settings.General.PortraitsFolder,
                    ConfigurationManager.Settings.General.PogsFolder);
            }

            Characters = CollectionViewSource.GetDefaultView(loader.Portifolios);
        }
    }
}
