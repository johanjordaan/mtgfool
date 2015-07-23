using System;
using System.Collections.Generic;
using mtgfool.Base;
using log4net;
using mtgfool.Utils;

namespace mtgfool.Objects
{
	public class Game:IdObject
	{
		ILog log = LogManager.GetLogger(typeof(Game));

		public Dictionary<string, Card> Cards { get; private set; }
		public void AddCard(Card card)
		{
			Cards.Add(card.Id, card);
		}

		public List<Player> Players { get; private set; }
		public void AddPlayer(Player player)
		{
			Players.Add(player);
			log.Info (String.Format ("Player [{0}] joined game [{1}]",player.Id,Id));
		}
		public Player ActivePlayer { get; private set; }

		public int TurnNumber { get; private set; }
		public bool Started { get; private set; }
		public bool Start()
		{
			if (Players.Count < 2) {
				log.Error (String.Format ("Cannot start game [{0}] with [{1}] players (At least 2 players required).",Id,Players.Count));
				return false;
			}
				
			Players.Shuffle ();
			ActivePlayer = Players [0];

			TurnNumber = 0;

			CurrentPhase = PHASE.Setup;

			Started = true;

			log.Info (String.Format ("Game [{0}] started with [{1}] players",Id,Players.Count));

			NextPhase ();

			return true;
		}

		private void nextPlayer()
		{
			var nextPlayerIndex = Players.IndexOf (ActivePlayer) +1;
			if (nextPlayerIndex >= Players.Count)
				nextPlayerIndex = 0;	
			ActivePlayer = Players [nextPlayerIndex];
		}

		private void nextTurn() 
		{
			nextPlayer ();
			TurnNumber++;
		}

		public PHASE CurrentPhase { get; private set; }
		public void NextPhase()
		{
			if (CurrentPhase == PHASE.Setup) {
				CurrentPhase = PHASE.Untap;
			} else if (CurrentPhase == PHASE.Untap) {
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
				CurrentPhase = PHASE.Untap;
			} 

			log.Info (String.Format ("Game [{0}], Turn [{1}], ActivePlayer [{2}], Phase [{3}]",Id,TurnNumber,ActivePlayer.Id,CurrentPhase.ToString()));
		}

		public List<Closure> GetValidActions()
		{
			var retVal = new List<Closure> ();
			foreach (var card in Cards) {
				foreach (var action in card.Value.CardTemplate.Actions) {
					var parameterLists = action.Value.GetParameters ().Expand(card.Value);
					foreach(var parameterList in parameterLists) { 
						if (action.Value.CanExecute (card.Value, parameterList)) {
							retVal.Add (new Closure (action.Value, card.Value, parameterList));
							Console.Out.WriteLine ("*[{0}] on [{1}] [{2}]", action.Key, card.Value.Name, card.Value.Id);
						} else {
							Console.Out.WriteLine(" [{0}] on [{1}] [{2}]",action.Key,card.Value.Name,card.Value.Id);
						}

					}
				}
			}

			return retVal;;
		}

		public Game():base()
		{
			Started = false;
			Cards = new Dictionary<string, Card>();
			Players = new List<Player> ();
			log.Info (String.Format ("New game [{0}] created",Id));
		}
	}
}

