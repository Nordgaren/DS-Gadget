using Binarysharp.Assemblers.Fasm;
using PropertyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace DS_Gadget
{
    public class DSHook : PHook
    {
        private const uint VERSION_RELEASE = 0xFC293654;
        private const uint VERSION_DEBUG = 0xCE9634B4;
        private const uint VERSION_BETA = 0xE91B11E2;

        private PHPointer CheckVersion;

        private PHPointer PosLock;
        private PHPointer NodeGraph;
        private PHPointer AllNoMagicQtyConsume;
        private PHPointer PlayerNoDead;
        private PHPointer PlayerExterminate;
        private PHPointer AllNoStaminaConsume;
        private PHPointer Compasses;
        private PHPointer CompassSmall;
        private PHPointer Altimeter;
        private PHPointer CompassLarge;
        private PHPointer DrawMapPtr;

        private PHPointer CharData1;
        private PHPointer CharMapData;
        private PHPointer AnimData;
        private PHPointer CharPosData;
        private PHPointer NewGameCycle;
        private PHPointer CharData2;
        private PHPointer Gestures;
        private PHPointer GraphicsData;
        private PHPointer WorldState;
        private PHPointer MenuManager;
        private PHPointer ChrFollowCam;
        private PHPointer EventFlags;
        private PHPointer Unknown1;
        private PHPointer Unknown2;
        private PHPointer Unknown3;
        private PHPointer Unknown4;

        private PHPointer BaseA;
        private PHPointer CurrentAnim;

        private PHPointer BaseB;
        private PHPointer BodyProportions;

        private PHPointer FuncItemGet;
        private PHPointer FuncLevelUp;
        private PHPointer FuncBonfireWarp;
        private PHPointer FuncBonfireWarpUnknown1;
        private PHPointer FuncItemDrop;
        private PHPointer FuncItemDropUnknown1;
        private PHPointer FuncItemDropUnknown2;

        private PHPointer InfiniteDurability;
        private PHPointer InfiniteDurabilitySpec;

        public int ID => Process?.Id ?? -1;
        public string Version { get; private set; }

        public DSHook(int refreshInterval, int minLifetime) :
            base(refreshInterval, minLifetime, p => p.MainWindowTitle == "DARK SOULS" || p.MainWindowTitle.Contains("DARK SOULS - PHANTOM BREAK"))
        {
            Version = "None";

            CheckVersion = CreateBasePointer((IntPtr)DSOffsets.CheckVersion);

            PosLock = RegisterAbsoluteAOB(DSOffsets.PosLockAOB);
            NodeGraph = RegisterAbsoluteAOB(DSOffsets.NodeGraphAOB);
            AllNoMagicQtyConsume = RegisterAbsoluteAOB(DSOffsets.AllNoMagicQtyConsumeAOB, DSOffsets.AllNoMagicQtyConsumeAOBOffset);
            PlayerNoDead = RegisterAbsoluteAOB(DSOffsets.PlayerNoDeadAOB, DSOffsets.PlayerNoDeadAOBOffset);
            PlayerExterminate = RegisterAbsoluteAOB(DSOffsets.PlayerExterminateAOB, DSOffsets.PlayerExterminateAOBOffset);
            AllNoStaminaConsume = RegisterAbsoluteAOB(DSOffsets.AllNoStaminaConsumeAOB, DSOffsets.AllNoStaminaConsumeAOBOffset);
            Compasses = RegisterAbsoluteAOB(DSOffsets.CompassAOB);
            CompassSmall = CreateChildPointer(Compasses, DSOffsets.CompassSmallAOBOffset);
            Altimeter = CreateChildPointer(Compasses, DSOffsets.AltimeterAOBOffset);
            CompassLarge = CreateChildPointer(Compasses, DSOffsets.CompassLargeAOBOffset);
            DrawMapPtr = RegisterAbsoluteAOB(DSOffsets.DrawMapAOB, DSOffsets.DrawMapAOBOffset);

            CharData1 = RegisterAbsoluteAOB(DSOffsets.CharData1AOB, DSOffsets.CharData1AOBOffset, DSOffsets.CharData1Offset1, DSOffsets.CharData1Offset2, DSOffsets.CharData1Offset3);
            CharMapData = CreateChildPointer(CharData1, (int)DSOffsets.CharData1.CharMapDataPtr);
            AnimData = CreateChildPointer(CharMapData, (int)DSOffsets.CharMapData.AnimDataPtr);
            CharPosData = CreateChildPointer(CharMapData, (int)DSOffsets.CharMapData.CharPosDataPtr);
            NewGameCycle = RegisterAbsoluteAOB(DSOffsets.CharData2AOB, DSOffsets.CharData2AOBOffset, DSOffsets.CharData2Offset1);
            CharData2 = CreateChildPointer(NewGameCycle, DSOffsets.CharData2Offset2);
            Gestures = CreateChildPointer(CharData2, (int)DSOffsets.CharData2.GesturesUnlockedPtr);
            GraphicsData = RegisterAbsoluteAOB(DSOffsets.GraphicsDataAOB, DSOffsets.GraphicsDataAOBOffset, DSOffsets.GraphicsDataOffset1, DSOffsets.GraphicsDataOffset2);
            WorldState = RegisterAbsoluteAOB(DSOffsets.WorldStateAOB, DSOffsets.WorldStateAOBOffset, DSOffsets.WorldStateOffset1);
            MenuManager = RegisterAbsoluteAOB(DSOffsets.MenuManagerAOB, DSOffsets.MenuManagerAOBOffset, DSOffsets.MenuManagerOffset1);
            ChrFollowCam = RegisterAbsoluteAOB(DSOffsets.ChrFollowCamAOB, DSOffsets.ChrFollowCamAOBOffset, DSOffsets.ChrFollowCamOffset1, DSOffsets.ChrFollowCamOffset2, DSOffsets.ChrFollowCamOffset3);
            EventFlags = RegisterAbsoluteAOB(DSOffsets.EventFlagsAOB, DSOffsets.EventFlagsAOBOffset, DSOffsets.EventFlagsOffset1, DSOffsets.EventFlagsOffset2);
            Unknown1 = RegisterAbsoluteAOB(DSOffsets.Unknown1AOB, DSOffsets.Unknown1AOBOffset, DSOffsets.Unknown1Offset1);
            Unknown2 = RegisterAbsoluteAOB(DSOffsets.Unknown2AOB, DSOffsets.Unknown2AOBOffset, DSOffsets.Unknown2Offset1);
            Unknown3 = RegisterAbsoluteAOB(DSOffsets.Unknown3AOB, DSOffsets.Unknown3AOBOffset, DSOffsets.Unknown3Offset1);
            Unknown4 = RegisterAbsoluteAOB(DSOffsets.Unknown4AOB, DSOffsets.Unknown4AOBOffset, DSOffsets.Unknown4Offset1, DSOffsets.Unknown4Offset2);

            BaseA = RegisterAbsoluteAOB(DSOffsets.BaseAAoB, DSOffsets.BaseAAoBOffset1, DSOffsets.BaseAAoBOffset2);
            CurrentAnim = CreateChildPointer(BaseA, (int)DSOffsets.CurrentAnimAOBOffset1, (int)DSOffsets.CurrentAnimAOBOffset2, (int)DSOffsets.CurrentAnimAOBOffset3);

            BaseB = RegisterAbsoluteAOB(DSOffsets.BaseBAoB, DSOffsets.BaseBAoBOffset1, DSOffsets.BaseBAoBOffset2);
            BodyProportions = CreateChildPointer(BaseB, DSOffsets.BodyProportionsOffset);

            FuncItemGet = RegisterAbsoluteAOB(DSOffsets.FuncItemGetAOB);
            FuncLevelUp = RegisterAbsoluteAOB(DSOffsets.FuncLevelUpAOB);
            FuncBonfireWarp = RegisterAbsoluteAOB(DSOffsets.FuncBonfireWarpAOB);
            FuncBonfireWarpUnknown1 = RegisterAbsoluteAOB(DSOffsets.FuncBonfireWarpUnknown1AOB, DSOffsets.FuncBonfireWarpUnknown1AOBOffset);
            FuncItemDrop = RegisterAbsoluteAOB(DSOffsets.FuncItemDropAOB);
            FuncItemDropUnknown1 = RegisterAbsoluteAOB(DSOffsets.FuncItemDropUnknown1AOB, DSOffsets.FuncItemDropUnknown1AOBOffset);
            FuncItemDropUnknown2 = RegisterAbsoluteAOB(DSOffsets.FuncItemDropUnknown2AOB, DSOffsets.FuncItemDropUnknown2AOBOffset);

            InfiniteDurability = RegisterAbsoluteAOB(DSOffsets.InfiniteDurabilityAoB);
            InfiniteDurabilitySpec = RegisterAbsoluteAOB(DSOffsets.InfiniteDurabilitySpecAoB);

            OnHooked += DSHook_OnHooked;
            OnUnhooked += DSHook_OnUnhooked;
        }

        private void DSHook_OnHooked(object sender, PHEventArgs e)
        {
            uint version = CheckVersion.ReadUInt32(0);
            switch (version)
            {
                case VERSION_RELEASE:
                    Version = "Steam";
                    break;

                case VERSION_DEBUG:
                    Version = "Debug";
                    break;

                case VERSION_BETA:
                    Version = "Steamworks Beta";
                    break;

                default:
                    Version = $"Unknown 0x{version:X8}";
                    break;
            }
        }

        private void DSHook_OnUnhooked(object sender, PHEventArgs e)
        {
            Version = "None";
        }

        public bool Loaded => ChrFollowCam.Resolve() != IntPtr.Zero;

        public bool Focused => Hooked && User32.GetForegroundProcessID() == Process.Id;

        private void AsmExecute(string asm)
        {
            // Assemble once to determine size
            byte[] bytes = FasmNet.Assemble("use32\norg 0x0\n" + asm);
            IntPtr insertPtr = Allocate((uint)bytes.Length);
            // Then rebase and inject
            // Note: you can't use String.Format here because IntPtr is not IFormattable
            bytes = FasmNet.Assemble("use32\norg 0x" + insertPtr.ToString("X") + "\n" + asm);
            Kernel32.WriteBytes(Handle, insertPtr, bytes);
            Execute(insertPtr);
            Free(insertPtr);
        }

        #region Player Tab
        public int Health
        {
            get => CharData1.ReadInt32((int)DSOffsets.CharData1.HP);
            set => CharData1.WriteInt32((int)DSOffsets.CharData1.HP, value);
        }

        public int HealthMax => CharData2.ReadInt32((int)DSOffsets.CharData2.HPMax);
        public int HealthModMax => CharData2.ReadInt32((int)DSOffsets.CharData2.HPModMax);

        public int Stamina
        {
            get => CharData1.ReadInt32((int)DSOffsets.CharData1.Stamina);
            set => CharData1.WriteInt32((int)DSOffsets.CharData1.Stamina, value);
        }

        public int StaminaMax => CharData2.ReadInt32((int)DSOffsets.CharData2.StaminaMax);
        public int StaminaModMax => CharData2.ReadInt32((int)DSOffsets.CharData2.StaminaModMax);

        public int ChrType
        {
            get => CharData1.ReadInt32((int)DSOffsets.CharData1.ChrType);
            set => CharData1.WriteInt32((int)DSOffsets.CharData1.ChrType, value);
        }

        public int TeamType
        {
            get => CharData1.ReadInt32((int)DSOffsets.CharData1.TeamType);
            set => CharData1.WriteInt32((int)DSOffsets.CharData1.TeamType, value);
        }

        public int PlayRegion
        {
            get => CharData1.ReadInt32((int)DSOffsets.CharData1.PlayRegion);
            set => CharData1.WriteInt32((int)DSOffsets.CharData1.PlayRegion, value);
        }

        public byte World => Unknown1.ReadByte((int)DSOffsets.Unknown1.World);
        public byte Area => Unknown1.ReadByte((int)DSOffsets.Unknown1.Area);

        public void SetPosLock(bool enable)
        {
            if (enable)
            {
                PosLock.WriteBytes(DSOffsets.PosLock1AOBOffset, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 });
                PosLock.WriteBytes(DSOffsets.PosLock2AOBOffset, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 });
            }
            else
            {
                PosLock.WriteBytes(DSOffsets.PosLock1AOBOffset, new byte[] { 0x66, 0x0F, 0xD6, 0x46, 0x10 });
                PosLock.WriteBytes(DSOffsets.PosLock2AOBOffset, new byte[] { 0x66, 0x0F, 0xD6, 0x46, 0x18 });
            }
        }

        public void SetPos(float x, float y, float z)
        {
            PosX = x;
            PosY = y;
            PosZ = z;
        }

        

        public float PosX
        {
            get => CharPosData.ReadSingle((int)DSOffsets.CharPosData.PosX);
            set => CharPosData.WriteSingle((int)DSOffsets.CharPosData.PosX, value);
        }

        public float PosY
        {
            get => CharPosData.ReadSingle((int)DSOffsets.CharPosData.PosY);
            set => CharPosData.WriteSingle((int)DSOffsets.CharPosData.PosY, value);
        }

        IntPtr InfiniteDurabilitySpecPtr;
        internal void InfiniteDurabilitySpecToggle(bool enable)
        {
            if (enable)
                EnableDurability(ref InfiniteDurabilitySpecPtr, InfiniteDurabilitySpec, Properties.Resources.InfiniteDurabilitySpec, Properties.Resources.InfiniteDurabilitySpecInject);
            else
                DisableDurability(ref InfiniteDurabilitySpecPtr, InfiniteDurabilitySpec, new byte[] { 0x89, 0x50, 0x14, 0xB0, 0x01 });
        }

        IntPtr InfiniteDurabilityPtr;
        internal void InfiniteDurabilityToggle(bool enable)
        {
            if (enable)
                EnableDurability(ref InfiniteDurabilityPtr, InfiniteDurability, Properties.Resources.InfiniteDurability, Properties.Resources.InfiniteDurabilityInject);
            else
                DisableDurability(ref InfiniteDurabilityPtr, InfiniteDurability, new byte[] { 0x89, 0x53, 0x14, 0x3B, 0x71, 0x10 });
        }
        private void EnableDurability(ref IntPtr durabilityPtr, PHPointer pHPointer, string newCode, string injectCode)
        {
            var asm = string.Format(newCode,
               0xFF00);
            var bytes = FasmNet.Assemble("use32\norg 0x0\n" + asm); // Have to get the bytes once to calculate the total size of bytes
            durabilityPtr = Allocate((uint)bytes.Length, Kernel32.PAGE_EXECUTE_READWRITE);

            var asmInject = string.Format(injectCode,
             GetRelativeOffset(pHPointer.Resolve(), durabilityPtr)); 
            var injectBytes = FasmNet.Assemble("use32\norg 0x0\n" + asmInject); //Get the size of inject code,
           
            asm = string.Format(Properties.Resources.InfiniteDurability,
               GetRelativeOffset(durabilityPtr, pHPointer.Resolve() + injectBytes.Length));
            bytes = FasmNet.Assemble("use32\norg 0x0\n" + asm);
            Kernel32.WriteBytes(Handle, durabilityPtr, bytes);

            pHPointer.WriteBytes(0x0, injectBytes);
        }
        private void DisableDurability(ref IntPtr durabilityPtr, PHPointer pHPointer, byte[] bytes)
        {
            pHPointer.WriteBytes(0x0, bytes);
            Free(durabilityPtr);
            durabilityPtr = IntPtr.Zero;
        }
        private int GetRelativeOffset(IntPtr source, IntPtr dest)
        {
            return dest.ToInt32() - source.ToInt32();
        }

        public float PosZ
        {
            get => CharPosData.ReadSingle((int)DSOffsets.CharPosData.PosZ);
            set => CharPosData.WriteSingle((int)DSOffsets.CharPosData.PosZ, value);
        }

        public float PosAngle
        {
            get => CharPosData.ReadSingle((int)DSOffsets.CharPosData.PosAngle);
            set => CharPosData.WriteSingle((int)DSOffsets.CharPosData.PosAngle, value);
        }

        public float PosStableX => WorldState.ReadSingle((int)DSOffsets.WorldState.PosStableX);
        public float PosStableY => WorldState.ReadSingle((int)DSOffsets.WorldState.PosStableY);
        public float PosStableZ => WorldState.ReadSingle((int)DSOffsets.WorldState.PosStableZ);
        public float PosStableAngle => WorldState.ReadSingle((int)DSOffsets.WorldState.PosStableAngle);

        public void PosWarp(float x, float y, float z, float angle)
        {
            CharMapData.WriteSingle((int)DSOffsets.CharMapData.WarpX, x);
            CharMapData.WriteSingle((int)DSOffsets.CharMapData.WarpY, y);
            CharMapData.WriteSingle((int)DSOffsets.CharMapData.WarpZ, z);
            CharMapData.WriteSingle((int)DSOffsets.CharMapData.WarpAngle, angle);
            CharMapData.WriteBoolean((int)DSOffsets.CharMapData.Warp, true);
        }

        public byte[] DumpFollowCam()
        {
            return ChrFollowCam.ReadBytes(0, 512);
        }

        public void UndumpFollowCam(byte[] bytes)
        {
            ChrFollowCam.WriteBytes(0, bytes);
        }

        public void SetGravity(bool enable)
        {
            CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDisableGravity, !enable);
        }

        public void SetCollision(bool enable)
        {
            CharMapData.WriteFlag32((int)DSOffsets.CharMapData.CharMapFlags, (uint)DSOffsets.CharMapFlags.DisableMapHit, !enable);
        }

        public bool DeathCam
        {
            get => Unknown2.ReadBoolean((int)DSOffsets.Unknown2.DeathCam);
            set => Unknown2.WriteBoolean((int)DSOffsets.Unknown2.DeathCam, value);
        }

        public int LastBonfire
        {
            get => WorldState.ReadInt32((int)DSOffsets.WorldState.LastBonfire);
            set => WorldState.WriteInt32((int)DSOffsets.WorldState.LastBonfire, value);
        }

        public void BonfireWarp()
        {
            string asm = string.Format(Properties.Resources.BonfireWarp,
                (int)FuncBonfireWarpUnknown1.Resolve(), (int)FuncBonfireWarp.Resolve());
            AsmExecute(asm);
        }

        public void SetSpeed(float speed)
        {
            AnimData.WriteSingle((int)DSOffsets.AnimData.PlaySpeed, speed);
        }

        #endregion

        #region Stats Tab
        public string CharName
        {
            get => CharData2.ReadString((int)DSOffsets.CharData2.CharName, Encoding.Unicode, 0x22);
            set => CharData2.WriteString((int)DSOffsets.CharData2.CharName, Encoding.Unicode, 0x22, value);
        }

        public short Sex
        {
            get => CharData2.ReadInt16((int)DSOffsets.CharData2.Sex);
            set => CharData2.WriteInt16((int)DSOffsets.CharData2.Sex, value);
        }

        public byte Class
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.Class);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.Class, value);
        }

        public byte Physique
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.Physique);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.Physique, value);
        }

        internal void ChangePhysique(float head, float chest, float waist, float hands, float legs)
        {
            BodyProportions.WriteSingle((int)DSOffsets.BodyProportions.Head, head);
            BodyProportions.WriteSingle((int)DSOffsets.BodyProportions.Chest, chest);
            BodyProportions.WriteSingle((int)DSOffsets.BodyProportions.Abdomen, waist);
            BodyProportions.WriteSingle((int)DSOffsets.BodyProportions.Arms, hands);
            BodyProportions.WriteSingle((int)DSOffsets.BodyProportions.Legs, legs);
        }

        public int SoulLevel
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.SoulLevel);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.SoulLevel, value);
        }
        [Control("nudHumanity")]
        public int Humanity
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Humanity);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Humanity, value);
        }
        [Control("nudSouls")]
        public int Souls
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Souls);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Souls, value);
        }
        [Control("nudVit")]
        public int Vitality
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Vitality);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Vitality, value);
        }
        [Control("nudAtt")]
        public int Attunement
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Attunement);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Attunement, value);
        }
        [Control("nudEnd")]
        public int Endurance
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Endurance);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Endurance, value);
        }
        [Control("nudStr")]
        public int Strength
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Strength);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Strength, value);
        }
        [Control("nudDex")]
        public int Dexterity
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Dexterity);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Dexterity, value);
        }
        [Control("nudRes")]
        public int Resistance
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Resistance);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Resistance, value);
        }
        [Control("nudInt")]
        public int Intelligence
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Intelligence);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Intelligence, value);
        }
        [Control("nudFth")]
        public int Faith
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.Faith);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.Faith, value);
        }

        public void LevelUp(int vitality, int attunement, int endurance, int strength, int dexterity, int resistance, int intelligence, int faith, int level)
        {
            int humanity = Humanity;

            IntPtr stats = Allocate(2048);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Vitality, vitality);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Attunement, attunement);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Endurance, endurance);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Strength, strength);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Dexterity, dexterity);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Resistance, resistance);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Intelligence, intelligence);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Faith, faith);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.SoulLevel, level);
            Kernel32.WriteInt32(Handle, stats + (int)DSOffsets.FuncLevelUp.Souls, Souls);

            string asm = string.Format(Properties.Resources.LevelUp,
                (int)stats, (int)FuncLevelUp.Resolve());

            AsmExecute(asm);
            Free(stats);

            Humanity = humanity;
        }
        [Control("nudCovSunlight")]
        public byte WarriorOfSunlightPoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.WarriorOfSunlightPoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.WarriorOfSunlightPoints, value);
        }
        [Control("nudCovDarkwraith")]
        public byte DarkwraithPoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.DarkwraithPoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.DarkwraithPoints, value);
        }
        [Control("nudCovDragon")]
        public byte PathOfTheDragonPoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.PathOfTheDragonPoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.PathOfTheDragonPoints, value);
        }
        [Control("nudCovGravelord")]
        public byte GravelordServantPoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.GravelordServantPoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.GravelordServantPoints, value);
        }
        [Control("nudCovForest")]
        public byte ForestHunterPoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.ForestHunterPoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.ForestHunterPoints, value);
        }
        [Control("nudCovDarkmoon")]
        public byte DarkmoonBladePoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.DarkmoonBladePoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.DarkmoonBladePoints, value);
        }
        [Control("nudCovChaos")]
        public byte ChaosServantPoints
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.ChaosServantPoints);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.ChaosServantPoints, value);
        }

        public byte Covenant
        {
            get => CharData2.ReadByte((int)DSOffsets.CharData2.Covenant);
            set => CharData2.WriteByte((int)DSOffsets.CharData2.Covenant, value);
        }
        #endregion

        #region Indexer
        //This indexer will take a name and match it to the Control Attribute name above each property
        public int this[string attributeName]
        {
            get
            {
                //Get each property
                var props = typeof(DSHook).GetProperties();
                foreach (var prop in props)
                {
                    //Check if it has a ControlAttribute with the same name
                    var Attr = prop.GetCustomAttribute<ControlAttribute>();
                    if (Attr != null && Attr.Name == attributeName)
                        return Convert.ToInt32(prop.GetValue(this, null)); //Return matching Control Attribute as int?
                }
                throw new MissingMemberException("DSHook", attributeName);
            }
            set
            {
                //Get each property
                var props = typeof(DSHook).GetProperties();
                foreach (var prop in props)
                {
                    //Check if it has a ControlAttribute with the same name
                    var Attr = prop.GetCustomAttribute<ControlAttribute>();
                    if (Attr != null && Attr.Name == attributeName)
                    {
                        if (prop.PropertyType.Equals(typeof(byte)))
                            prop.SetValue(this, (byte)value, null); //Set the properties value
                        else
                            prop.SetValue(this, value, null); //Set the properties value

                        return;
                    }
                }
                throw new MissingMemberException("DSHook", attributeName);

            }
        }
        #endregion

        #region Items Tab
        public void GetItem(int category, int itemID, int count)
        {
            string asm = string.Format(Properties.Resources.ItemGet,
                (int)CharData2.Resolve() + (int)DSOffsets.CharData2.InventoryIndexStart, category, itemID, count, (int)FuncItemGet.Resolve());

            AsmExecute(asm);
        }

        public void DropItem(int category, int itemID, int count)
        {
            string asm = string.Format(Properties.Resources.ItemDrop,
                category, itemID, count, (int)FuncItemDropUnknown1.Resolve(), (int)FuncItemDropUnknown2.Resolve(), (int)FuncItemDrop.Resolve());

            AsmExecute(asm);
        }
        #endregion

        #region Graphics Tab
        public void DrawBounding(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.DrawBoundingBoxes, enable);
        }

        public void DrawSpriteMasks(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.DepthDraw_DepthTexEdge, enable);
        }

        public void DrawTextures(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.DrawTextures, enable);
        }

        public void DrawSprites(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.NormalDraw_TexEdge, enable);
        }

        public void DrawTrans(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.NormalDraw_Trans, enable);
        }

        public void DrawShadows(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.DrawShadows, enable);
        }

        public void DrawSpriteShadows(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.DrawSpriteShadows, enable);
        }

        public void DrawMap(bool enable)
        {
            DrawMapPtr.WriteBoolean((int)DSOffsets.DrawMap.DrawMap, enable);
        }

        public void DrawCreatures(bool enable)
        {
            DrawMapPtr.WriteBoolean((int)DSOffsets.DrawMap.DrawCreatures, enable);
        }

        public void DrawObjects(bool enable)
        {
            DrawMapPtr.WriteBoolean((int)DSOffsets.DrawMap.DrawObjects, enable);
        }

        public void DrawSFX(bool enable)
        {
            DrawMapPtr.WriteBoolean((int)DSOffsets.DrawMap.DrawSFX, enable);
        }

        public void DrawCompassLarge(bool enable)
        {
            CompassLarge.WriteBoolean(0, enable);
        }

        public void DrawCompassSmall(bool enable)
        {
            CompassSmall.WriteBoolean(0, enable);
        }

        public void DrawAltimeter(bool enable)
        {
            Altimeter.WriteBoolean(0, enable);
        }

        public void DrawNodes(bool enable)
        {
            // Code edit, yikes
            NodeGraph.WriteBoolean(DSOffsets.NodeGraphAOBOffset, enable);
        }

        public void OverrideFilter(bool enable)
        {
            GraphicsData.WriteBoolean((int)DSOffsets.GraphicsData.EnableFilter, enable);
        }

        public void SetBrightness(float brightnessR, float brightnessG, float brightnessB)
        {
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.BrightnessR, brightnessR);
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.BrightnessG, brightnessG);
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.BrightnessB, brightnessB);
        }

        public void SetContrast(float contrastR, float contrastG, float contrastB)
        {
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.ContrastR, contrastR);
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.ContrastG, contrastG);
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.ContrastB, contrastB);
        }

        public void SetSaturation(float saturation)
        {
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.Saturation, saturation);
        }

        public void SetHue(float hue)
        {
            GraphicsData.WriteSingle((int)DSOffsets.GraphicsData.Hue, hue);
        }
        #endregion

        #region Cheats Tab
        public bool PlayerDeadMode
        {
            get => CharData1.ReadFlag32((int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDeadMode);
            set => CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetDeadMode, value);
        }

        public void SetPlayerNoDamage(bool enable)
        {
            CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoDamage, enable);
        }

        public void SetPlayerNoHit(bool enable)
        {
            CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoHit, enable);
        }

        public void SetPlayerNoStamina(bool enable)
        {
            CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoStamConsume, enable);
        }

        public void SetPlayerSuperArmor(bool enable)
        {
            CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags1, (uint)DSOffsets.CharFlags1.SetSuperArmor, enable);
        }

        public void SetPlayerNoGoods(bool enable)
        {
            CharData1.WriteFlag32((int)DSOffsets.CharData1.CharFlags2, (uint)DSOffsets.CharFlags2.NoGoodsConsume, enable);
        }

        public void SetAllNoMagic(bool enable)
        {
            AllNoMagicQtyConsume.WriteBoolean(0, enable);
        }

        public void SetNoDead(bool enable)
        {
            PlayerNoDead.WriteBoolean(0, enable);
        }

        public void SetExterminate(bool enable)
        {
            PlayerExterminate.WriteBoolean(0, enable);
        }

        public void SetAllStamina(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoStaminaConsume, enable);
        }

        public void SetAllMP(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoMPConsume, enable);
        }

        public void SetAllAmmo(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoArrowConsume, enable);
        }

        public void SetHide(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.PlayerHide, enable);
        }

        public void SetSilence(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.PlayerSilence, enable);
        }

        public void SetAllNoDead(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoDead, enable);
        }

        public void SetAllNoDamage(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoDamage, enable);
        }

        public void SetAllNoHit(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoHit, enable);
        }

        public void SetAllNoAttack(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoAttack, enable);
        }

        public void SetAllNoMove(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoMove, enable);
        }

        public void SetAllNoUpdateAI(bool enable)
        {
            AllNoStaminaConsume.WriteBoolean((int)DSOffsets.ChrDbg.AllNoUpdateAI, enable);
        }

        #endregion

        #region Internals Tab
        public int EquipRight1Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRight1Idx);
        public int EquipRight1ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRight1ID);
        public int EquipRight2Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRight2Idx);
        public int EquipRight2ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRight2ID);
        public int EquipLeft1Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipLeft1Idx);
        public int EquipLeft1ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipLeft1ID);
        public int EquipLeft2Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipLeft2Idx);
        public int EquipLeft2ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipLeft2ID);
        public int EquipArrow1Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipArrow1Idx);
        public int EquipArrow1ID
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipArrow1ID);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.EquipArrow1ID, value);
        }
        public int EquipArrow2Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipArrow2Idx);
        public int EquipArrow2ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipArrow2ID);
        public int EquipBolt1Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipBolt1Idx);
        public int EquipBolt1ID
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipBolt1ID);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.EquipBolt1ID, value);
        }
        public int EquipBolt2Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipBolt2Idx);
        public int EquipBolt2ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipBolt2ID);
        public int EquipHelmetIdx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipHelmetIdx);
        public int EquipHelmetID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipHelmetID);
        public int EquipChestIdx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipChestIdx);
        public int EquipChestID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipChestID);
        public int EquipGloveIdx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipGloveIdx);
        public int EquipGloveID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipGloveID);
        public int EquipPantsIdx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipPantsIdx);
        public int EquipPantsID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipPantsID);

        public int EquipHairIdx
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipHairIdx);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.EquipHairIdx, value);
        }

        public int EquipHairID
        {
            get => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipHairID);
            set => CharData2.WriteInt32((int)DSOffsets.CharData2.EquipHairID, value);
        }

        public int EquipRing1Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRing1Idx);
        public int EquipRing1ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRing1ID);
        public int EquipRing2Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRing2Idx);
        public int EquipRing2ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipRing2ID);
        public int EquipItem1Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem1Idx);
        public int EquipItem1ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem1ID);
        public int EquipItem2Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem2Idx);
        public int EquipItem2ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem2ID);
        public int EquipItem3Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem3Idx);
        public int EquipItem3ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem3ID);
        public int EquipItem4Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem4Idx);
        public int EquipItem4ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem4ID);
        public int EquipItem5Idx => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem5Idx);
        public int EquipItem5ID => CharData2.ReadInt32((int)DSOffsets.CharData2.EquipItem5ID);

        public int StoredMagic => Unknown4.ReadInt32((int)DSOffsets.Unknown4.StoredMagic);
        public int StoredItem => CharData1.ReadInt32((int)DSOffsets.CharData1.StoredItem);
        public int StoredQuantity => MenuManager.ReadInt32((int)DSOffsets.MenuManager.QuantityDefault);

        public float HairColorRed
        {
            get => CharData2.ReadSingle((int)DSOffsets.CharData2.HairColorRed);
            set => CharData2.WriteSingle((int)DSOffsets.CharData2.HairColorRed, value);
        }

        public float HairColorGreen
        {
            get => CharData2.ReadSingle((int)DSOffsets.CharData2.HairColorGreen);
            set => CharData2.WriteSingle((int)DSOffsets.CharData2.HairColorGreen, value);
        }

        public float HairColorBlue
        {
            get => CharData2.ReadSingle((int)DSOffsets.CharData2.HairColorBlue);
            set => CharData2.WriteSingle((int)DSOffsets.CharData2.HairColorBlue, value);
        }

        public float EyeColorRed
        {
            get => CharData2.ReadSingle((int)DSOffsets.CharData2.EyeColorRed);
            set => CharData2.WriteSingle((int)DSOffsets.CharData2.EyeColorRed, value);
        }

        public float EyeColorGreen
        {
            get => CharData2.ReadSingle((int)DSOffsets.CharData2.EyeColorGreen);
            set => CharData2.WriteSingle((int)DSOffsets.CharData2.EyeColorGreen, value);
        }

        public float EyeColorBlue
        {
            get => CharData2.ReadSingle((int)DSOffsets.CharData2.EyeColorBlue);
            set => CharData2.WriteSingle((int)DSOffsets.CharData2.EyeColorBlue, value);
        }
        #endregion

        #region Misc Tab
        private static Dictionary<string, int> eventFlagGroups = new Dictionary<string, int>()
        {
            {"0", 0x00000},
            {"1", 0x00500},
            {"5", 0x05F00},
            {"6", 0x0B900},
            {"7", 0x11300},
        };

        private static Dictionary<string, int> eventFlagAreas = new Dictionary<string, int>()
        {
            {"000", 00},
            {"100", 01},
            {"101", 02},
            {"102", 03},
            {"110", 04},
            {"120", 05},
            {"121", 06},
            {"130", 07},
            {"131", 08},
            {"132", 09},
            {"140", 10},
            {"141", 11},
            {"150", 12},
            {"151", 13},
            {"160", 14},
            {"170", 15},
            {"180", 16},
            {"181", 17},
            {"990", 00}
        };

        private int getEventFlagOffset(int ID, out uint mask)
        {
            string idString = ID.ToString("D8");
            if (idString.Length == 8)
            {
                string group = idString.Substring(0, 1);
                string area = idString.Substring(1, 3);
                int section = int.Parse(idString.Substring(4, 1));
                int number = int.Parse(idString.Substring(5, 3));

                if (eventFlagGroups.ContainsKey(group) && eventFlagAreas.ContainsKey(area))
                {
                    int offset = eventFlagGroups[group];
                    offset += eventFlagAreas[area] * 0x500;
                    offset += section * 128;
                    offset += (number - (number % 32)) / 8;

                    mask = 0x80000000 >> (number % 32);
                    return offset;
                }
            }
            throw new ArgumentException("Unknown event flag ID: " + ID);
        }

        public bool ReadEventFlag(int ID)
        {
            int offset = getEventFlagOffset(ID, out uint mask);
            return EventFlags.ReadFlag32(offset, mask);
        }

        public void WriteEventFlag(int ID, bool state)
        {
            int offset = getEventFlagOffset(ID, out uint mask);
            EventFlags.WriteFlag32(offset, mask, state);
        }

        public void UnlockAllGestures()
        {
            foreach (int offset in Enum.GetValues(typeof(DSOffsets.Gestures)))
            {
                // This is not, strictly speaking, the right way to do this
                // But I don't, strictly speaking, really care
                Gestures.WriteFlag32(offset, 1, true);
            }
        }

        public int NewGame
        {
            get => NewGameCycle.ReadInt32((int)DSOffsets.CharData2.NewGame);
            set => NewGameCycle.WriteInt32((int)DSOffsets.CharData2.NewGame, value);
        }
        #endregion

        #region Hotkeys Tab
        public void MenuKick()
        {
            Unknown3.WriteInt32((int)DSOffsets.Unknown3.MenuKick, 2);
        }

        public void MoveSwap()
        {
            // Is this Int64 for a reason???
            CharData2.WriteInt64((int)DSOffsets.CharData2.Stance, 2);
        }

        public void ResetAnim()
        {
            CurrentAnim.WriteInt32(0x60, -1);
            CharData1.WriteInt32((int)DSOffsets.CharData1.ForcePlayAnimation1, 1);
        }

        public void HotkeyTest1()
        {

        }

        public void HotkeyTest2()
        {

        }
        #endregion
    }
}
