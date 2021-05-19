﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class DSBonfire : IComparable<DSBonfire>
    {
        private static Regex bonfireEntryRx = new Regex(@"^(?<id>\S+) (?<name>.+)$");

        public string Name;
        public int ID;

        private DSBonfire(string config)
        {
            Match bonfireEntry = bonfireEntryRx.Match(config);
            Name = bonfireEntry.Groups["name"].Value;
            ID = Convert.ToInt32(bonfireEntry.Groups["id"].Value);
        }

        public DSBonfire(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(DSBonfire other)
        {
            return Name.CompareTo(other.Name);
        }

        public static List<DSBonfire> All = new List<DSBonfire>();

        static DSBonfire()
        {
            foreach (string line in Regex.Split(GetTxtResourceClass.GetTxtResource("Resources/Bonfires.txt"), "[\r\n]+"))
                All.Add(new DSBonfire(line));
            All.Sort();
        }
    }
}
