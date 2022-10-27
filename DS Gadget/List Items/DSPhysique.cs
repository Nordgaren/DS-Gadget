using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class DSPhysique : IComparable<DSPhysique>
    {
        private static readonly Regex PhysiqueEntryRx = new Regex(@"^(?<id>\d+) (?<name>[a-zA-Z- ]+) (?<head>[0-9.-]+) (?<chest>[0-9.-]+) (?<waist>[0-9.-]+) (?<hands>[0-9.-]+) (?<legs>[0-9.-]+)$", RegexOptions.CultureInvariant);

        public byte ID { get; }
        public string Name { get; }
        public float Head { get; set; }
        public float Chest { get; set; }
        public float Waist { get; set; }
        public float Hands { get; set; }
        public float Legs { get; set; }

        public DSPhysique(byte id, string name, float head, float chest, float waist, float hands, float legs)
        {
            ID = id;
            Name = name;
            Head = head;
            Chest = chest;
            Waist = waist;
            Hands = hands;
            Legs = legs;
        }

        public int CompareTo(DSPhysique other) => Name.CompareTo(other.Name);

        public override string ToString() => Name;

        public static IReadOnlyList<DSPhysique> All { get; }

        static DSPhysique()
        {
            var all = new List<DSPhysique>();
            foreach (string line in Regex.Split(GetTxtResourceClass.GetTxtResource("Resources/Systems/Other/Physiques.txt"), "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                {
                    Match match = PhysiqueEntryRx.Match(line);
                    byte id = byte.Parse(match.Groups["id"].Value);
                    string name = match.Groups["name"].Value;
                    float head = Convert.ToSingle(match.Groups["head"].Value, CultureInfo.InvariantCulture);
                    float chest =Convert.ToSingle(match.Groups["chest"].Value, CultureInfo.InvariantCulture);
                    float waist =Convert.ToSingle(match.Groups["waist"].Value, CultureInfo.InvariantCulture);
                    float hands =Convert.ToSingle(match.Groups["hands"].Value, CultureInfo.InvariantCulture);
                    float legs = Convert.ToSingle(match.Groups["legs"].Value, CultureInfo.InvariantCulture);
                    all.Add(new DSPhysique(id, name, head, chest, waist, hands, legs));
                };
            }
            all.Sort();
            All = all;
        }
    }
}
