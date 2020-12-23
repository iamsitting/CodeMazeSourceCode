using System;
using System.Linq;

namespace Simple
{
	public class SimpleClass
	{
		public string GetLastName(string fullName)
		{
			var names = fullName.Split(" ");
			var lastName = names.LastOrDefault();
			return lastName ?? string.Empty;
		}
	}
}

