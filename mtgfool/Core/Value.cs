using System;

namespace mtgfool.Core
{
	public class Value
	{
		public ValueLimits Limits { get; private set; }
		public int Initial { get; private set; }
		public int Current { get; private set; }


		public bool Inc(int amount) {
			if(Limits.HasMax)
				if (Current + amount > Limits.Max)
					return false;

			Current += amount;
			return true;
		}

		public bool Dec(int amount) {
			if(Limits.HasMin)
				if (Current - amount < Limits.Min)
					return false;

			Current -= amount;
			return true;
		}

		public void Reset() {
			Current = Initial;
		}

		public Value ()
		{
			Limits = new ValueLimits (0, false, 0, false);
			Initial = 0;
			Current = Initial;
		}

		public Value (int initial)
		{
			Limits = new ValueLimits (0, false, 0, false);
			Initial = initial;
			Current = Initial;
		}

		public Value (int initial,ValueLimits limits)
		{
			Limits = limits;
			Initial = initial;
			Current = Initial;
		}
	}
}

