using BenchmarkDotNet.Running;
using SensitiveWordsBenchMark;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<WordMaskerBenchmark>();
