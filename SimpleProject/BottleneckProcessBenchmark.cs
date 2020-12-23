using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SimpleProject
{
	public class BottleneckProcessBenchmark
	{
		private const string csvString = "Code,Maze";
		private static readonly BottleneckProcess process = new BottleneckProcess();

		[Benchmark]
		public void GetLastItem()
		{
			process.GetLastItem(csvString);
		}
	}
}

