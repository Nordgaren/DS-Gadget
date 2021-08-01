using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;

namespace DS_Gadget
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoadSavedStatsBenchmark
    {
        private readonly SavedStats SavedStats = new SavedStats() 
        {
         Name = "1337",

         Sex = 1,

         Class = 1,

         Physique = 1,

         Humanity = 69,

         Souls = 420,

         Vit = 69,

         Att = 69,

         End = 69,

         Str = 69,

         Dex = 69,

         Res = 69,

         Int = 69,

         Fth = 69,

         Covenant = 5,

         CovChaos = 69,

         CovDarkmoon = 69,

         CovDarkwraith = 69,

         CovForest = 69,

         CovGravelord = 69,

         CovDragon = 69,

         CovSunlight = 69,
    };

        private readonly GadgetTabStats gadgetTabStats = new GadgetTabStats();

        private readonly MainForm Main = new MainForm();

        [Benchmark]
        public void LoadSavedStatsIfStatementsAll ()
        {
            gadgetTabStats.InitTab(Main);
            gadgetTabStats.LoadSavedStatsIf(SavedStats);
        }
    }
}
