using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Core {
    public enum FileEntryType {
        Portifolio  = 0x10, // (*.por)
        Portrait    = 0x30, // (*.jpg|*.jpeg|*.png|*.gif)
        POG         = 0x40, // (*.jpg|*.jpeg|*.png|*.gif)
        Image       = 0x20, // (*.jpg|*.jpeg|*.png|*.gif)
        Token       = 0x50, // (*.rptok)
        All         = 0x100 // (*.*)
    }
}
