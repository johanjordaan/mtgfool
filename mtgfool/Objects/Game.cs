using System;
using System.Collections.Generic;
using mtgfool.Base;

namespace mtgfool.Objects
{
	public class Game:IdObject
	{
		public Dictionary<string, Card> Cards { get; private set; }
		public void AddCard(Card card)
		{
			Cards.Add(card.Id, card);
		}

		public List<Player> Players { get; private set; }
		public void AddPlayer(Player player)
		{
			Players.Add(player);
		}
		public Player ActivePlayer { get; private set; }

		public int TurnNumber { get; private set; }
		public bool Started { get; private set; }
		public bool Start()
		{
			if (Players.Count < 2)
				return false;

			var r = new Random (); 
			ActivePlayer = Players[r.Next (Players.Count)];

			TurnNumber = 0;

			Started = true;

			return true;
		}

		private void nextPlayer()
		{
			var i = Players.IndexOf (ActivePlayer);
			if (i + 1 < Players.Count)
				i = 0;
			else
				i++;

			ActivePlayer = Players [i];

		}


		private void nextTurn() 
		{
			nextPlayer ();
			TurnNumber++;
		}

		public PHASE CurrentPhase { get; private set; }
		public void NextPhase()
		{
			if (CurrentPhase == PHASE.Untap) {
				CurrentPhase = PHASE.Upkeep;
			} else if (CurrentPhase == PHASE.Upkeep) {
				CurrentPhase = PHASE.Draw;
			} else if (CurrentPhase == PHASE.Draw) {
				CurrentPhase = PHASE.FirstMain;
			} else if (CurrentPhase == PHASE.FirstMain) {
				CurrentPhase = PHASE.Combat;
			} else if (CurrentPhase == PHASE.Combat) {
				CurrentPhase = PHASE.SecondMain;
			} else if (CurrentPhase == PHASE.SecondMain) {
				CurrentPhase = PHASE.End;
			} else if (CurrentPhase == PHASE.End) {
				nextTurn ();
			} 
		}


		public Game():base()
		{
			Started = false;
			Cards = new Dictionary<string, Card>();
			Players = new List<Player> ();
		}
	}
}

