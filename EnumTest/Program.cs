using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var fields = typeof(Operations)
				.GetFields(BindingFlags.Public | BindingFlags.Static)
				.Where(f => f.GetCustomAttribute<MyAttribute>() != null)
				.ToArray();

			Enum x = Operations.IsBlank;
			var y = fields[0].GetValue(null);

			var xArr = new[] { x };
			var yArr = new[] { y };
			var zArr = xArr.Where(a => yArr.Contains(a));
			Console.WriteLine(fields.Count());
			Console.ReadLine();
		}
	}

	public enum Operations
	{
		StartsWith,
		Is,
		[My]
		IsBlank,
		IsNot,
		[My]
		IsNotBlank
	};

	public class MyAttribute : Attribute
	{
	}

}
