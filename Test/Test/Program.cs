namespace Test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			/*object name1 = Person.Name;

			//var Empl = new Employee().GetInformation();
			var information = Person.Name == (new Employee().GetInformation());
			Console.WriteLine(information);
			var name2 = Person.Name;
			var Empl2 = new Employee().GetInformation();
			var information2 = (new Employee().GetInformation()) == Person.Name;
			Console.WriteLine(information2);
			var information3 = (new Me().GetInformation()) == Person.Name;
			Console.WriteLine(information3);
			var Empl = new Employee().GetInformation();
			Console.WriteLine(Empl);
			*/

			string s = "one";
			string r = s;
			string w = s.Insert(1, "d");
			
			Console.WriteLine(r);
			Console.WriteLine(s);
			Console.WriteLine(w);


		}


	}
		public abstract class Person
		{
			public static string Name = "Not defined";
			public Person() => Name = GetInformation();
			public abstract string GetInformation();
		}
		public class Employee : Person
		{
			public override string GetInformation() => "I am an employee";
		}

		public class Me : Employee
		{
			public override string GetInformation() => "I am";
		}
}
