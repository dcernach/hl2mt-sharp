using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Microsoft.Win32;
using MeHZ.HeroLab2MapTool.Core;

namespace MeHZ.HeroLab2MapTool.App.Controls {
    /// <summary>
    /// Interaction logic for CharacterGrid.xaml
    /// </summary>
    public partial class CharacterGrid : UserControl {
        private CharacterViewModel Model = null;

        public CharacterGrid() {
            InitializeComponent();
            Model = new CharacterViewModel();
        }


        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            // Thanks to: 
            // http://www.thebestcsharpprogrammerintheworld.com/blogs/How-to-capture-double-click-event-in-Data-Grid-row-using-WPF.aspx

            var grid = (DataGrid)sender;
            var cell = grid.SelectedCells;
            var scol = cell.FirstOrDefault();

            if (scol.Column == null) {
                return;
            }

            var cidx = scol.Column.DisplayIndex;
            var item = (PortifolioMetadata)scol.Item;

            if (scol.Column.Header.ToString() != "Portrait" || scol.Column.Header.ToString() != "Token")

            if (cidx > 1)
                return;

            if(cidx == 0) {
                var path = System.IO.Path.GetDirectoryName(item.PortraitImage);
                var file = SelectNewImage(path);
                item.PortraitImage = string.IsNullOrWhiteSpace(file) ? item.PortraitImage : file;
            }

            if (cidx == 1) {
                var path = System.IO.Path.GetDirectoryName(item.PogImage);
                var file = SelectNewImage(path);
                item.PogImage = string.IsNullOrWhiteSpace(file) ? item.PogImage : file;
            }
        }


        private string SelectNewImage(string basePath) {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Valid Image Files|*.png;*.jpg;*.jpeg;*.gif";
            openFileDialog.InitialDirectory = basePath;

            var result = openFileDialog.ShowDialog();
            if (result == true) {
                return openFileDialog.FileName;
            }
            return null;
        }


        private void btnProcessFiles_Click(object sender, RoutedEventArgs e) {
            //BindingOperations.ClearAllBindings(dataGrid);
            //dataGrid.ItemsSource = null;
            //DataContext = Model;
            Model.ProcessFiles();
            dataGrid.ItemsSource = Model.Characters;
        }


        private void btnCreateTokens_Click(object sender, RoutedEventArgs e) {
            var t = (IEnumerable<PortifolioMetadata>)Model.Characters.SourceCollection;
        }
    }
}
