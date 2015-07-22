using System;
using System.Collections.Generic;

using mtgfool.Base;

namespace mtgfool.Objects
{
	public class Card : IdObject,IContext
	{

		public String Name { get; private set; }
		//public Dictionary<string, List<IFunction<Card>>> Actions { get; private set; }
		public Player Player { get; private set; }

		public bool Tapped { get; private set; }
		public void Tap()
		{
			Tapped = true;
		}
		public void Untap()
		{
			Tapped = false;
		}


		public LOCATION Location { get; private set; }
		public void SetLocation(LOCATION newLocation)
		{
			Location = newLocation;
		}

		public Card(string name,Player player):base()
		{

			Name = name;
			Player = player;

			Location = LOCATION.Library;

			Player.Game.AddCard(this);
		}
	}
}

