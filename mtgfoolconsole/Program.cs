﻿using System;
using mtgfool;
using log4net.Config;

namespace mtgfoolconsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BasicConfigurator.Configure ();

			var game = new mtgfool.Objects.Game ();
			var player1 = new mtgfool.Objects.Player ("Johan",game);
			var player2 = new mtgfool.Objects.Player ("Liliana",game);
			var mountain = mtgfool.Objects.CardFactory.GetInstance ("Mountain", player1);

			mountain.SetLocation (mtgfool.Objects.LOCATION.Hand);

			game.AddPlayer (player1);
			game.AddPlayer (player2);
			game.Start ();

			while (game.TurnNumber < 3) {
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
