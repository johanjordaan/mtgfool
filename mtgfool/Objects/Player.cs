using System;
using mtgfool.Base;

namespace mtgfool.Objects
{
	public class Player : IdObject
	{
		public string Name { get; private set; }
		public Game Game { get; private set; }
		public ManaPool ManaPool { get; private set; }

		public Player(string name, Game game):base()
		{
			Name = name;
			Game = game;
			ManaPool = new ManaPool();
		}
	}
}

