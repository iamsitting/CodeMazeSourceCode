using BenchmarkDotNet.Running;

namespace Simple
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<SimpleBenchmark>();
		}
	}
}

