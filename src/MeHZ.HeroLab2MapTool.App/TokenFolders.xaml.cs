using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MeHZ.HeroLab2MapTool.App.Resources;
using MeHZ.HeroLab2MapTool.Core;
using MeHZ.HeroLab2MapTool.Core.Configuration;

namespace MeHZ.HeroLab2MapTool.App {
    /// <summary>
    /// Interaction logic for TokenFolders.xaml
    /// </summary>
    public partial class TokenFolders : System.Windows.Window {
        public General Model { get; private set; }

        public TokenFolders() {
            InitializeComponent();
            DataContext = ConfigurationManager.Settings.General;
        }


        private void btnSelectInput_Click(object sender, RoutedEventArgs e) {
            var folder = SelectFolder(FileEntryType.Portifolio);
            ConfigurationManager.Settings.General.InputFolder = folder;
        }


        private void btnSelectPog_Click(object sender, RoutedEventArgs e) {
            var folder = SelectFolder(FileEntryType.POG);
            ConfigurationManager.Settings.General.PogsFolder = folder;
        }


        private void btnSelectPortrait_Click(object sender, RoutedEventArgs e) {
            var folder = SelectFolder(FileEntryType.Portrait);
            ConfigurationManager.Settings.General.PortraitsFolder = folder;
        }


        private void btnSelectOutput_Click(object sender, RoutedEventArgs e) {
            var folder = SelectFolder(FileEntryType.Token);
            ConfigurationManager.Settings.General.OutputFolder = folder;
        }


        private void btnOK_Click(object sender, RoutedEventArgs e) {
            ConfigurationManager.Save();
            Close();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }


        private string SelectFolder(FileEntryType folderType) {
            var fsd = new FolderSelectDialog();
            fsd.Title = string.Format("Select {0} folder", folderType.ToString()); 
            //fsd.InitialDirectory = Environment.
            if (fsd.ShowDialog(IntPtr.Zero)) {
                Console.WriteLine(fsd.FileName);
            }

            return fsd.FileName;
        }


        private void chkInputFolderScan_Click(object sender, RoutedEventArgs e) {

        }
    }
}
