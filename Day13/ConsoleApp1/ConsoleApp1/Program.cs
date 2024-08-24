namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Query expression
			//where select => query operators

			//List<string> list = new List<string>() {"1", "C# Turorials", "VB.Net" , "1"};

			//var res = from s in list
			//		  where s.Contains("C#")
			//		  select s;

			//var res = list.Distinct();

			// defered execution
			// immediate .count . min .tolist .max .avg
			//foreach (var s in res) { 
			//	Console.WriteLine(s);
			//}

			//compiler : query => fluent expression

			//var res2 = list.Where(s => s.Contains("C#"));
			//foreach (var s in res2)
			//{
			//	Console.WriteLine(s);
			//}

			//---------------------------------------------------------
			var max = new[] {1 , 2 , 3}.Max();	
		}
	}
}
