using Bluegrams.Application;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace DS_Gadget
{

    static class OldSettings
    {
        public static Point WindowLocation;
        public static int HotkeyMoveswap;
        public static decimal HealInterval;
        public static bool UpgradeRequired;
        public static bool FilterBrightnessSync;
        public static int HotkeyDown;
        public static int HotkeyTest2;
        public static int HotkeyUp;
        public static decimal FilterContrastG;
        public static int HotkeyDeath;
        public static decimal FilterBrightnessR;
        public static int HotkeyFilter;
        public static decimal FilterContrastR;
        public static bool FilterEnable;
        public static decimal Speed;
        public static int HotkeyMenu;
        public static int HotkeyCollision;
        public static int HotkeyRestore;
        public static bool HandleHotkeys;
        public static int HotkeyTest1;
        public static int HotkeySpeed;
        public static decimal FilterBrightnessG;
        public static int HotkeyAnim;
        public static decimal FilterSaturation;
        public static bool FilterContrastSync;
        public static int HotkeyAI;
        public static bool EnableHotkeys;
        public static int HotkeyStore;
        public static bool StoreHP;
        public static int HotkeyGravity;
        public static decimal FilterHue;
        public static decimal FilterContrastB;
        public static int HotkeyItem;
        public static decimal FilterBrightnessB;
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Properties.Settings settings = Properties.Settings.Default;
            OldSettings.WindowLocation = settings.WindowLocation;
            OldSettings.HotkeyMoveswap = settings.HotkeyMoveswap;
            OldSettings.HealInterval = settings.HealInterval;
            OldSettings.UpgradeRequired = settings.UpgradeRequired;
            OldSettings.FilterBrightnessSync = settings.FilterBrightnessSync;
            OldSettings.HotkeyDown = settings.HotkeyDown;
            OldSettings.HotkeyTest2 = settings.HotkeyTest2;
            OldSettings.HotkeyUp = settings.HotkeyUp;
            OldSettings.FilterContrastG = settings.FilterContrastG;
            OldSettings.HotkeyDeath = settings.HotkeyDeath;
            OldSettings.FilterBrightnessR = settings.FilterBrightnessR;
            OldSettings.HotkeyFilter = settings.HotkeyFilter;
            OldSettings.FilterContrastR = settings.FilterContrastR;
            OldSettings.FilterEnable = settings.FilterEnable;
            OldSettings.Speed = settings.Speed;
            OldSettings.HotkeyMenu = settings.HotkeyMenu;
            OldSettings.HotkeyCollision = settings.HotkeyCollision;
            OldSettings.HotkeyRestore = settings.HotkeyRestore;
            OldSettings.HandleHotkeys = settings.HandleHotkeys;
            OldSettings.HotkeyTest1 = settings.HotkeyTest1;
            OldSettings.HotkeySpeed = settings.HotkeySpeed;
            OldSettings.FilterBrightnessG = settings.FilterBrightnessG;
            OldSettings.HotkeyAnim = settings.HotkeyAnim;
            OldSettings.FilterSaturation = settings.FilterSaturation;
            OldSettings.FilterContrastSync = settings.FilterContrastSync;
            OldSettings.HotkeyAI = settings.HotkeyAI;
            OldSettings.EnableHotkeys = settings.EnableHotkeys;
            OldSettings.HotkeyStore = settings.HotkeyStore;
            OldSettings.StoreHP = settings.StoreHP;
            OldSettings.HotkeyGravity = settings.HotkeyGravity;
            OldSettings.FilterHue = settings.FilterHue;
            OldSettings.FilterContrastB = settings.FilterContrastB;
            OldSettings.HotkeyItem = settings.HotkeyItem;
            OldSettings.FilterBrightnessB = settings.FilterBrightnessB;
            PortableSettingsProvider.ApplyProvider(Properties.Settings.Default);
            settings.WindowLocation = OldSettings.WindowLocation;
            settings.HotkeyMoveswap = OldSettings.HotkeyMoveswap;
            settings.HealInterval = OldSettings.HealInterval;
            settings.UpgradeRequired = OldSettings.UpgradeRequired;
            settings.FilterBrightnessSync = OldSettings.FilterBrightnessSync;
            settings.HotkeyDown = OldSettings.HotkeyDown;
            settings.HotkeyTest2 = OldSettings.HotkeyTest2;
            settings.HotkeyUp = OldSettings.HotkeyUp;
            settings.FilterContrastG = OldSettings.FilterContrastG;
            settings.HotkeyDeath = OldSettings.HotkeyDeath;
            settings.FilterBrightnessR = OldSettings.FilterBrightnessR;
            settings.HotkeyFilter = OldSettings.HotkeyFilter;
            settings.FilterContrastR = OldSettings.FilterContrastR;
            settings.FilterEnable = OldSettings.FilterEnable;
            settings.Speed = OldSettings.Speed;
            settings.HotkeyMenu = OldSettings.HotkeyMenu;
            settings.HotkeyCollision = OldSettings.HotkeyCollision;
            settings.HotkeyRestore = OldSettings.HotkeyRestore;
            settings.HandleHotkeys = OldSettings.HandleHotkeys;
            settings.HotkeyTest1 = OldSettings.HotkeyTest1;
            settings.HotkeySpeed = OldSettings.HotkeySpeed;
            settings.FilterBrightnessG = OldSettings.FilterBrightnessG;
            settings.HotkeyAnim = OldSettings.HotkeyAnim;
            settings.FilterSaturation = OldSettings.FilterSaturation;
            settings.FilterContrastSync = OldSettings.FilterContrastSync;
            settings.HotkeyAI = OldSettings.HotkeyAI;
            settings.EnableHotkeys = OldSettings.EnableHotkeys;
            settings.HotkeyStore = OldSettings.HotkeyStore;
            settings.StoreHP = OldSettings.StoreHP;
            settings.HotkeyGravity = OldSettings.HotkeyGravity;
            settings.FilterHue = OldSettings.FilterHue;
            settings.FilterContrastB = OldSettings.FilterContrastB;
            settings.HotkeyItem = OldSettings.HotkeyItem;
            settings.FilterBrightnessB = OldSettings.FilterBrightnessB;
            settings.Save();
            //if (settings.UpgradeRequired)
            //{
            //    settings.Upgrade();
            //    settings.UpgradeRequired = false;
            //}
            


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

        }
    }
}
