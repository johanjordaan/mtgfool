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

		public Game():base()
		{
			Cards = new Dictionary<string, Card>();
		}
	}
}

