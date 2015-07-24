using System;
using mtgfool;
using log4net.Config;

namespace mtgfoolconsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BasicConfigurator.Configure ();

			var game = new mtgfool.Core.Game ();
			var player1 = new mtgfool.Core.Player ("Johan",game);
			var player2 = new mtgfool.Core.Player ("Liliana",game);
			var mountain = mtgfool.Core.CardFactory.GetInstance ("Mountain", player1);

			mountain.SetLocation (mtgfool.Core.LOCATION.Hand);

			game.AddPlayer (player1);
			game.AddPlayer (player2);
			game.Start ();

			while (game.TurnNumber < 4) {
				game.NextPhase ();
				var va = game.GetValidActions ();
				if (va.Count > 0) {
					va [0].Execute ();
				}
					
			}


			//Console.WriteLine ("Hello World! "+mountain.Id);
		}
	}
}
