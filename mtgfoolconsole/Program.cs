using System;
using mtgfool;

namespace mtgfoolconsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var m = new mtgfool.Objects.ManaPool ();

			m.Add (mtgfool.Objects.COLOR.Red, -10);

			Console.WriteLine ("Hello World!");
		}
	}
}
