using System;

namespace mtgfool.Core
{
	public class ValueLimits
	{
		public int Min { get; private set; }
		public bool HasMin { get; private set; }
		public int Max { get; private set; }
		public bool HasMax { get; private set; }

		public ValueLimits(int min,bool hasMin,int max,bool hasMax) {
			Min = min;
			HasMin = hasMin;
			Max = max;
			HasMax = hasMax;
		}
	}
}

