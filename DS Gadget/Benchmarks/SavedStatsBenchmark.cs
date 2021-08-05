using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DS_Gadget
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SavedStatsBenchmark
    {
        private readonly GadgetTabStats gadgetTabStats = new GadgetTabStats();

        public SavedStatsBenchmark()
        {
            gadgetTabStats.MakeDictsPub();
        }

        private readonly string[] NudNames = new string[]
        {
            "nudHumanity", "nudSouls", "nudVit", "nudAtt", "nudEnd", "nudStr",
            "nudDex", "nudRes", "nudInt", "nudFth", "nudCovChaos", "nudCovDarkmoon",
            "nudCovDarkwraith", "nudCovForest", "nudCovGravelord", "nudCovDragon",
            "nudCovSunlight"
        };
        
        private readonly Random rand = new Random();

        [Benchmark(Baseline = true)]
        public void SaveStatsSwitchBenchmark()
        {
            var i = rand.Next(NudNames.Length);
            gadgetTabStats.SaveStatsSwitch(new NumericUpDown() { Name = NudNames[i], Value = 69 });
        }

        [Benchmark]
        public void SaveStatsDictBenchmark()
        {
            var i = rand.Next(NudNames.Length);
            gadgetTabStats.SavedStatsDict(new NumericUpDown() { Name = NudNames[i], Value = 69 });
        }

        [Benchmark]
        public void SaveStatsReflectBenchmark()
        {
            var i = rand.Next(NudNames.Length);
            gadgetTabStats.SaveStatsReflection(new NumericUpDown() { Name = NudNames[i], Value = 69 });
        }

        [Benchmark]
        public void SaveStatsReflectLinqBenchmark()
        {
            var i = rand.Next(NudNames.Length);
            gadgetTabStats.SaveStatsReflectionLinq(new NumericUpDown() { Name = NudNames[i], Value = 69 });
        }
    }
}
