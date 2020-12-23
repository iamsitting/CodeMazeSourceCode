using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Simple
{
	[MemoryDiagnoser]
	public class SimpleBenchmakr
	{
		private const string FullName = "Code Maze";
		private static readonly SimpleClass parser = new SimpleClass();

		[Benchmark(Baseline = true)]
		public void GetLastName()
		{
			parser.GetLastName(FullName);
		}
	}
}

