using System;

namespace mtgfool.Core
{
	public class Value
	{
		public int Min { get; private set; }
		public int Initial { get; private set; }
		public int Current { get; private set; }
		public int Max { get; private set; }
		public FREQUENCY ResetFrequency { get; private set;}

		public bool Inc(int amount) {
			if (Current + amount > Max)
				return false;

			Current += amount;
			return true;
		}

		public bool Dec(int amount) {
			if (Current - amount < Min)
				return false;

			Current -= amount;
			return true;
		}

		public void Reset() {
			Current = Initial;
		}

		public Value (int min,int max,int initial,FREQUENCY resetFrequency)
		{
			Min = min;
			Max = max;
			Initial = initial;
			Current = Initial;
		}
	}
}

