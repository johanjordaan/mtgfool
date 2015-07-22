using System;
using System.Collections.Generic;

using mtgfool.Base;

namespace mtgfool.Objects
{
	public class Card : IdObject,IContext
	{
		public ICardTemplate CardTemplate { get; private set; }
		public Player Player { get; private set; }

		public string Name 
		{
			get {
				return String.Format ("{0}[{1}]", CardTemplate.Name, Id);
			}
		}


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

		public Card(ICardTemplate cardTemplate,Player player):base()
		{
			CardTemplate = cardTemplate; 
			Player = player;

			Location = LOCATION.Library;

			Player.Game.AddCard(this);
		}
	}
}

