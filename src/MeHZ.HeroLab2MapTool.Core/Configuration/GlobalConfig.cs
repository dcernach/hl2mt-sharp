using System;
using System.ComponentModel;

namespace MeHZ.HeroLab2MapTool.Core.Configuration {
    public class GlobalConfig {
        public General            General            { get; set; }
        public Window             Window             { get; set; }
        public CampaignProperties CampaignProperties { get; set; }
        public TokenProperties    TokenProperties    { get; set; }
        public Macros             Macros             { get; set; }
        public MacrosConfig       MacrosConfig       { get; set; }
    }

    public class General: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        string  _inputFolder;
        string  _portraitsFolder;
        string  _pogsFolder;
        string  _outputFolder;
        bool    _inputFolderScan;

        public string InputFolder {
            get {
                return _inputFolder;
            }

            set {
                _inputFolder = value;
                NotifyPropertyChanged("InputFolder");
            }
        }

        public string PortraitsFolder {
            get {
                return _portraitsFolder;
            }

            set {
                _portraitsFolder = value;
                NotifyPropertyChanged("PortraitsFolder");
            }
        }

        public string PogsFolder {
            get {
                return _pogsFolder;
            }

            set {
                _pogsFolder = value;
                NotifyPropertyChanged("PogsFolder");
            }
        }

        public string OutputFolder {
            get {
                return _outputFolder;
            }

            set {
                _outputFolder = value;
                NotifyPropertyChanged("OutputFolder");
            }
        }

        public bool InputFolderScan {
            get {
                return _inputFolderScan;
            }

            set {
                _inputFolderScan = value;
                NotifyPropertyChanged("InputFolderScan");
            }
        }

        public void NotifyPropertyChanged(string propName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class Window {
        public Size     Size     { get; set; }
        public Position Position { get; set; }
        public int      State    { get; set; }
    }

    public class Position {
        public double Top  { get; set; }
        public double Left { get; set; }
    }

    public class Size {
        public double Width  { get; set; }
        public double Height { get; set; }
    }

    public class CampaignProperties {
        public string TokenType           { get; set; }
        public bool   UseDarkVisionRanges { get; set; }
        public States States              { get; set; }
    }

    public class States {
        public string Woundedx1 { get; set; }
        public string Woundedx2 { get; set; }
        public string Woundedx3 { get; set; }
        public string Disabled  { get; set; }
        public string Dying     { get; set; }
        public string Dead      { get; set; }
    }

    public class TokenProperties {
        public string PlayerName    { get; set; }
        public string CharacterName { get; set; }
        public string Alignment     { get; set; }
        public string Race          { get; set; }
        public string Size          { get; set; }
        public string Reach         { get; set; }
        public string Speed         { get; set; }
        public string XPValue       { get; set; }
        public string Summary       { get; set; }
        public string Initiative    { get; set; }
        public string Senses        { get; set; }
        public string Strength      { get; set; }
        public string Dexterity     { get; set; }
        public string Constitution  { get; set; }
        public string Intelligence  { get; set; }
        public string Wisdom        { get; set; }
        public string Charisma      { get; set; }
        public string HPCurrent     { get; set; }
        public string HPMaximum     { get; set; }
        public string HPTemporary   { get; set; }
        public string BAB           { get; set; }
        public string CMB           { get; set; }
        public string MeleeBonus    { get; set; }
        public string RangedBonus   { get; set; }
        public string ACTotal       { get; set; }
        public string ACFlat        { get; set; }
        public string ACTouch       { get; set; }
        public string CMDTotal      { get; set; }
        public string CMDFlat       { get; set; }
    }

    public class Macros {
        public bool CreateInitiativeMacros    { get; set; }
        public bool CreateBasicAbilityMacros  { get; set; }
        public bool CreateBasicAttackMacros   { get; set; }
        public bool CreateBasicSaveMacros     { get; set; }
        public bool CreateBasicDiceMacros     { get; set; }
        public bool CreateBasicHitPointMacros { get; set; }
        public bool CreateWeaponMacros        { get; set; }
        public bool CreateManeouverMacros     { get; set; }
        public bool CreateSkillMacros         { get; set; }
        public bool CreateSpecialMacros       { get; set; }
        public bool CreateStatblockMacros     { get; set; }
    }

    public class MacrosConfig {
        public MacroOptions Initiative     { get; set; }
        public MacroOptions BasicAbility   { get; set; }
        public MacroOptions BasicAttack    { get; set; }
        public MacroOptions BasicSave      { get; set; }
        public MacroOptions BasicDice      { get; set; }
        public MacroOptions BasicHitPoint  { get; set; }
        public MacroOptions Weapon         { get; set; }
        public MacroOptions Maneouver      { get; set; }
        public MacroOptions Skill          { get; set; }
        public MacroOptions Special        { get; set; }
        public MacroOptions Statblock      { get; set; }
    }

    public class MacroOptions {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }
}