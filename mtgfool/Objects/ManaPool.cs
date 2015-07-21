using System;
using System.Collections.Generic;
using mtgfool.Utils;
using System.Diagnostics;

namespace mtgfool.Objects
{
	public class ManaPool
	{
		private Dictionary<COLOR, int> mana  = new Dictionary<COLOR, int>();
		public void Add(COLOR color,int amount) 
		{
			Trace.Assert (mana.ContainsKey (color));
			Trace.Assert (amount > 0);

			mana[color] += amount;
		}

		public bool Remove(COLOR color,int amount)
		{
			Trace.Assert (mana.ContainsKey (color));
			Trace.Assert (amount > 0);

			if (mana[color] < amount)
			{
				return false;
			}
			else
			{
				mana[color] -= amount;
				return true;
			}
		}

		public int this[COLOR key] 
		{
			get { return mana [key]; }
		}

		public void Clear()
		{
			mana.Clear();
			foreach (var color in EnumUtil.GetValues<COLOR>()) {
				mana [color] = 0;
			}
		}

		public ManaPool() 
		{
			Clear();
		}

	}
}

