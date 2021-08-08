﻿using System;
using System.Collections.Generic;


namespace DS_Gadget
{
    class DSItemCategory
    {
        public string Name;
        public List<DSItem> Items;

        private DSItemCategory(string name, int categoryID, string itemList, bool showIDs)
        {
            Name = name;
            Items = new List<DSItem>();
            foreach (string line in GetTxtResourceClass.RegexSplit(itemList, "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                    Items.Add(new DSItem(line, showIDs, categoryID));
            };
            Items.Sort();
        }

        public override string ToString()
        {
            return Name;
        }

        public static void GetItemCategories()
        {
            foreach (string line in GetTxtResourceClass.RegexSplit(GetTxtResourceClass.GetTxtResource("Resources/Equipment/DSItemCategories.txt"), "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                {
                    var att = GetTxtResourceClass.RegexSplit(line, ",");
                    Array.ForEach<string>(att, x => att[Array.IndexOf<string>(att, x)] = x.Trim());
                    All.Add(new DSItemCategory(att[0].Trim(), Convert.ToInt32(att[1].Trim(), 16), GetTxtResourceClass.GetTxtResource(att[2].Trim()), bool.Parse(att[3])));
                }
            };
        }

        public static List<DSItemCategory> All = new List<DSItemCategory>();
    }
}
