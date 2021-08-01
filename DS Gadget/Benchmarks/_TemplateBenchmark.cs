using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace DS_Gadget
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class TemplateBenchmark
    {
        [Benchmark]
        public void Method()
        {
        }
    }
}
