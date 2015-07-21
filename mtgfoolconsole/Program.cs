using System;
using mtgfool;

namespace mtgfoolconsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var game = new mtgfool.Objects.Game ();
			var player1 = new mtgfool.Objects.Player ("Johan",game);
			var mountain = mtgfool.Objects.CardFactory.GetInstance ("Mountain", player1);

			Console.WriteLine ("Hello World!");
		}
	}
}
