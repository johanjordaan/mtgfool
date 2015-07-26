using System;
using System.Collections.Generic;

using mtgfool.Utils;

namespace mtgfool.Core
{
	public class Card : IdObject,IContext
	{
		public ICardTemplate CardTemplate { get; private set; }
		public Player Player { get; private set; }
		public Game Game { get; private set; }

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
			EventHub.Signal (EventConstants.Tapped, this, null);
		}
		public void Untap()
		{
			Tapped = false;
			EventHub.Signal (EventConstants.Untapped, this, null);
		}


		public LOCATION Location { get; private set; }
		public void SetLocation(LOCATION newLocation)
		{
			Location = newLocation;
		}

		public Card(ICardTemplate cardTemplate,Player player, Game game):base()
		{
			CardTemplate = cardTemplate; 
			Player = player;

			Location = LOCATION.Library;

			Game = game;
			Game.AddCard(this);

			EventHub.AddObserver(EventConstants.StartOfStep,untapHandler);
		}


		private void untapHandler(IContext context,Dictionary<string,string> data) {
			if (Game.ActivePlayer == Player) {
				if (Game.CurrentStep == STEP.Untap) {
					Untap ();
				}
			}
		}
	}
}

