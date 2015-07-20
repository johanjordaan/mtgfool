using System;
using System.Collections.Generic;

namespace mtgfool.Objects
{
	public class Game
	{
		public Dictionary<string, Card> Cards { get; private set; }
		public void AddCard(Card card)
		{
			//Cards.Add(card.Id, card);
		}

		public List<Player> Players { get; private set; }
		public void AddPlayer(Player player)
		{
			Players.Add(player);
		}

		public Game()
		{
			Cards = new Dictionary<string, Card>();
		}
	}
}

