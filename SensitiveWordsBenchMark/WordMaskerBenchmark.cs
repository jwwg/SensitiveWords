using BenchmarkDotNet.Attributes;
using SensitiveWords.Model;
using SensitiveWordsTests;

namespace SensitiveWordsBenchMark
{
    public class WordMaskerBenchmark
    {
        private string _testMessage;

        [Params(1,10,100)]
        public int N;

        private readonly WordMasker _wordMasker = new WordMasker(new DummyWordService());
        private List<SensitiveWord> _data;


        [GlobalSetup]
        public void GlobalSetup()
        {
            _data = new DummyWordService().BadWords().Result;
            _testMessage = string.Join(" ",Enumerable.Range(1, N).
                Select(x => "SELECT * FROM BobbyTables; DROP DATABASE").
                ToArray());

        }



        [Benchmark(Baseline = true)]
        public void ParseMessage()
        {
           _wordMasker.ApplyMask(_testMessage, _data);
        }



    }
}
