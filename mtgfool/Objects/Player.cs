using System;

namespace mtgfool.Objects
{
	public class Player
	{
		public string Name { get; private set; }
		public Game Game { get; private set; }
		public ManaPool ManaPool { get; private set; }

		public Player(string name, Game game)
		{
			Name = name;
			Game = game;
			ManaPool = new ManaPool();
		}
	}
}

