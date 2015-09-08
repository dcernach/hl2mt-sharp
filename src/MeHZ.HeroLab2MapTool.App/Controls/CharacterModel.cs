using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.App.Controls {
    public class CharacterModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _portifolio;
        private string _name;
        private string _pogImage;
        private string _portraitImage;

        public string Portifolio {
            get { return _portifolio; }
            set {
                _portifolio = value; NotifyPropertyChanged("Portifolio");
            }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string PogImage {
            get { return _pogImage; }
            set {
                _pogImage = value;
                NotifyPropertyChanged("PogImage");
            }
        }

        public string PortraitImage {
            get { return _portraitImage; }
            set {
                _portraitImage = value;
                NotifyPropertyChanged("PortraitImage");
            }
        }

        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
