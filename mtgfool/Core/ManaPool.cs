using System;
using System.Collections.Generic;
using mtgfool.Utils;
using System.Diagnostics;

namespace mtgfool.Core
{
	public class ManaPool
	{
		private Dictionary<COLOR, Value> mana  = new Dictionary<COLOR, Value>();
		public bool Add(COLOR color,int amount) 
		{
			AssertAndThrow.IsTrue (mana.ContainsKey (color));
			AssertAndThrow.IsTrue (amount > 0);

			return mana[color].Inc(amount);
		}

		public bool Remove(COLOR color,int amount)
		{
			AssertAndThrow.IsTrue (mana.ContainsKey (color));
			AssertAndThrow.IsTrue (amount > 0);

			return mana [color].Dec (amount);
		}

		public int this[COLOR key] 
		{
			get { return mana [key].Current; }
		}

		public void Clear()
		{
			foreach (var color in EnumUtil.GetValues<COLOR>()) {
				mana [color].Reset();
			}
		}

		public ManaPool() 
		{
			foreach (var color in EnumUtil.GetValues<COLOR>()) {
				mana [color] = new Value (0,new ValueLimits(0,true,0,false));
			}

			EventHub.AddObserver(EventConstants.EndOfStep,(c,d)=>this.Clear());
		}

	}
}

