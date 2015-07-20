using System;
using System.Collections.Generic;

namespace mtgfool.Objects
{
	public class ManaPool
	{
		public enum COLOR { White, Blue, Black, Green, Red, Colorless }

		private Dictionary<COLOR, int> mana = new Dictionary<COLOR, int>();
		public void Add(COLOR color,int amount) 
		{
			if (!mana.ContainsKey(color))
				mana[color] = amount;
			else
				mana[color] += amount;
		}

		public bool Remove(COLOR color,int amount)
		{
			if (!mana.ContainsKey(color) || mana[color] < amount)
			{
				return false;
			}
			else
			{
				mana[color] -= amount;
				return true;
			}
		}

		public void Clear()
		{
			mana.Clear();
		}

		public ManaPool() 
		{
			Clear();
		}

	}
}

