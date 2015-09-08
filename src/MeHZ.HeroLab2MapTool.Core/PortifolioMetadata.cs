using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeHZ.HeroLab2MapTool.Core.Models;

namespace MeHZ.HeroLab2MapTool.Core {
    public class PortifolioMetadata: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _portifolioFile;
        private string _portraitImage;
        private string _pogImage;
        private bool _generateToken;
        private HerolabCharacter _heroLabCharacter;

        public PortifolioMetadata(HerolabCharacter entry) {
            HeroLabCharacter = entry;
        }


        public string PortifolioFile {
            get { return _portifolioFile; }
            set {
                _portifolioFile = value;
                NotifyPropertyChanged("PortifolioFile");
            }
        }

        public string PortraitImage {
            get { return _portraitImage; }
            set {
                _portraitImage = value;
                NotifyPropertyChanged("PortraitImage");
            }
        }

        public string PogImage {
            get { return _pogImage; }
            set {
                _pogImage = value;
                NotifyPropertyChanged("PogImage");
            }
        }

        public bool GenerateToken {
            get { return _generateToken; }
            set {
                _generateToken = value;
                NotifyPropertyChanged("GenerateToken");
            }
        }

        public HerolabCharacter HeroLabCharacter {
            get { return _heroLabCharacter; }
            set {
                _heroLabCharacter = value;
                NotifyPropertyChanged("HeroLabCharacter");
            }
        }

        //public HerolabCharacter XPTO {
        //    get { return _heroLabCharacter; }
        //    set {
        //        _heroLabCharacter = value;
        //        NotifyPropertyChanged("XPTO");
        //    }
        //}

        private void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
