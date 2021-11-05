using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DS_Gadget
{
    class TeamConfig
    {
        public string Name { get; set; }

        public int ChrType { get; set; }

        public int TeamType { get; set; }

        public TeamConfig()
        {
            Name = null;
            ChrType = 0;
            TeamType = 1;
        }

        public TeamConfig(string name, int chrType, int teamType)
        {
            Name = name;
            ChrType = chrType;
            TeamType = teamType;
        }

        public TeamConfig(string config)
        {
            var configEntry = configEntryRx.Match(config);
            Name = configEntry.Groups["name"].Value;
            ChrType = Convert.ToInt32(configEntry.Groups["chr"].Value);
            TeamType = Convert.ToInt32(configEntry.Groups["team"].Value);
        }

        private static Regex configEntryRx = new Regex(@"^(?<chr>\S+) (?<team>\S+) (?<name>.+)$");

        public static List<TeamConfig> GetConfigs()
        {
            var teamConfig = new List<TeamConfig>();
            foreach (string line in GetTxtResourceClass.RegexSplit(GetTxtResourceClass.GetTxtResource("Resources/Systems/TeamConfigs.txt"), "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                {
                    teamConfig.Add(new TeamConfig(line));
                }
            };

            return teamConfig;
        }

        public static List<TeamConfig> ArenaPlus = new List<TeamConfig>()
        {
            new TeamConfig("Arena+ Waiting(use orb in lobby)", 0, 4),
            new TeamConfig("Arena+ Host(use orb in lobby)", 0, 1),
            new TeamConfig("Arena+ Red(use orb in lobby)", 2, 6),
            new TeamConfig("Arena+ FFA(use orb in lobby)", 2, 16),
            new TeamConfig("Arena+ FFA Host(use orb in lobby)", 0, 16)
        };
    }
}
