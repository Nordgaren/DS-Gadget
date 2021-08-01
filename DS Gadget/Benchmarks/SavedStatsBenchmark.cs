using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SavedStatsBenchmark
    {
        private readonly string[] NudNames = new string[]
        {
            "nudHumanity", "nudSouls", "nudVit", "nudAtt", "nudEnd", "nudStr",
            "nudDex", "nudRes", "nudInt", "nudFth", "nudCovChaos", "nudCovDarkmoon",
            "nudCovDarkwraith", "nudCovForest", "nudCovGravelord", "nudCovDragon",
            "nudCovSunlight"
        };

        private readonly GadgetTabStats gadgetTabStats = new GadgetTabStats();

        private readonly Random rand = new Random();

        [Benchmark]
        public void SaveStatsSwitch()
        {
            var i = rand.Next(NudNames.Length);
            gadgetTabStats.SaveStatsBenchmark(new NumericUpDown() {Name = NudNames[i], Value = 69});
        }
    }
}
