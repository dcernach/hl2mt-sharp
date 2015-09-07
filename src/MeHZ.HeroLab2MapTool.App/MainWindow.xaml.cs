using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MeHZ.HeroLab2MapTool.Core;
using Microsoft.Win32;

namespace MeHZ.HeroLab2MapTool.App {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {


        public MainWindow() {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                Height      = ConfigurationManager.Settings.Window.Size.Height;
                Width       = ConfigurationManager.Settings.Window.Size.Width;
                Top         = ConfigurationManager.Settings.Window.Position.Top;
                Left        = ConfigurationManager.Settings.Window.Position.Left;
                WindowState = (WindowState)ConfigurationManager.Settings.Window.State;
            } catch(Exception) {
                // Do Nothing... Use defaults.
            }
        }


        private void Window_Closing(object sender, CancelEventArgs e)    {
            ConfigurationManager.Settings.Window.Size.Height = Height;
            ConfigurationManager.Settings.Window.Size.Width = Width;
            ConfigurationManager.Settings.Window.Position.Top = Top;
            ConfigurationManager.Settings.Window.Position.Left = Left;
            ConfigurationManager.Settings.Window.State = (int)WindowState;
            ConfigurationManager.Save();

            Application.Current.Shutdown();
        }


        private void MenuSave_Click(object sender, RoutedEventArgs e)    {
            ConfigurationManager.Save();
        }


        private void MenuImport_Click(object sender, RoutedEventArgs e)  {
            var importFileDialog = new OpenFileDialog();
            importFileDialog.Filter = "HeroLab2MapTool config file|*.hl2mt";
            importFileDialog.DefaultExt = ".hl2mt";

            var result = importFileDialog.ShowDialog();
            if (result == true) {
                var fileName = importFileDialog.FileName;
                ConfigurationManager.Import(fileName);
            }

            MessageBox.Show("Import completed successfully!", "Import", MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.OK);
        }


        private void MenuExport_Click(object sender, RoutedEventArgs e)  {
            var exportFileDialog = new SaveFileDialog();
            exportFileDialog.Filter = "HeroLab2MapTool config file|*.hl2mt";
            exportFileDialog.DefaultExt = ".hl2mt";

            var result = exportFileDialog.ShowDialog();
            if (result == true) {
                var fileName = exportFileDialog.FileName;
                ConfigurationManager.Export(fileName);
            }

            MessageBox.Show("Export completed successfully!", "Export", MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.OK);
        }


        private void MenuExit_Click(object sender, RoutedEventArgs e)    {
            Close();
        }


        private void MenuResetOptions_Click(object sender, RoutedEventArgs e) {
            var messageResult = MessageBox.Show("Are you sure you want to reset program options to defaults? \n" +
                "This action is undone!", "Reset Options",
                MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);

            if (messageResult == MessageBoxResult.Yes) {
                ConfigurationManager.Reset();
                ConfigurationManager.Save();
            }
        }


        private void MenuFolders_Click(object sender, RoutedEventArgs e) {
            var win = new TokenFolders();
            win.Owner = this;
            win.ShowDialog();
        }
    }
}
