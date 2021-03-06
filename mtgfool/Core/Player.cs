﻿using System;
using mtgfool.Utils;

namespace mtgfool.Core
{
	public class Player : IdObject,IContext
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

