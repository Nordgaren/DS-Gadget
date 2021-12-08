using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class DSPhysique : IComparable<DSPhysique>
    {
        private static Regex PhysiqueEntryRx = new Regex(@"^(?<id>\d+) (?<name>.*:+) (?<head>\S+) (?<chest>\S+) (?<waist>\S+) (?<hands>\S+) (?<legs>\S+)$");

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
                    string name = match.Groups["name"].Value.Replace(":", "");
                    float head = float.Parse(match.Groups["head"].Value);
                    float chest =float.Parse(match.Groups["chest"].Value);
                    float waist =float.Parse(match.Groups["waist"].Value);
                    float hands =float.Parse(match.Groups["hands"].Value);
                    float legs = float.Parse(match.Groups["legs"].Value);
                    all.Add(new DSPhysique(id, name, head, chest, waist, hands, legs));
                };
            }
            all.Sort();
            All = all;
        }
    }
}
