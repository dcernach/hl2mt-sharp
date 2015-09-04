namespace MeHZ.HeroLab2MapTool.Core.Configuration {
    public class GlobalConfig {
        public General            General            { get; set; }
        public Window             Window             { get; set; }
        public CampaignProperties CampaignProperties { get; set; }
        public TokenProperties    TokenProperties    { get; set; }
        public Macros             Macros             { get; set; }
        public MacrosConfig       MacrosConfig       { get; set; }
    }

    public class General {
        public string RootFolder         { get; set; }
        public string PortifoliosFolder  { get; set; }
        public string PortraitsFolder    { get; set; }
        public string PogsFolder         { get; set; }
        public string OutputFolder       { get; set; }
        public bool   RootFolderScanning { get; set; }
    }

    public class Window {
        public Position Position { get; set; }
        public Size     Size     { get; set; }
        public string   State    { get; set; }
    }

    public class Position {
        public int Top  { get; set; }
        public int Left { get; set; }
    }

    public class Size {
        public int Width  { get; set; }
        public int Height { get; set; }
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
        public Initiative    Initiative     { get; set; }
        public BasicAbility  BasicAbility   { get; set; }
        public BasicAttack   BasicAttack    { get; set; }
        public BasicSave     BasicSave      { get; set; }
        public BasicDice     BasicDice      { get; set; }
        public BasicHitPoint BasicHitPoint  { get; set; }
        public Weapon        Weapon         { get; set; }
        public Maneouver     Maneouver      { get; set; }
        public Skill         Skill          { get; set; }
        public Special       Special        { get; set; }
        public Statblock     Statblock      { get; set; }
    }

    public class Initiative {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class BasicAbility {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class BasicAttack {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class BasicSave {
        public string BackColor  { get; set; }
        public string FontColor  { get; set; }
        public string GroupName  { get; set; }
    }

    public class BasicDice {
        public string BackColor  { get; set; }
        public string FontColor  { get; set; }
        public string GroupName  { get; set; }
    }

    public class BasicHitPoint {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class Weapon {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class Maneouver {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class Skill {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class Special {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }

    public class Statblock {
        public string BackColor { get; set; }
        public string FontColor { get; set; }
        public string GroupName { get; set; }
    }
}