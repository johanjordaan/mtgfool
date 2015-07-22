using System;
using System.Collections.Generic;
using mtgfool.Objects;
using mtgfool.Base;

namespace mtgfool
{
	public class TapLandForMana:IFunction<Card>
	{
		public bool CanExecute (Card card,Dictionary<string, string> parameters)
		{
			var target = parameters["target"];
			COLOR color;
			Enum.TryParse<COLOR>(parameters["color"],out color);

			if (card.Location != LOCATION.Battlefield)
				return false;
			if (card.Id != target)
				return false;
			if (card.Tapped)
				return false;

			return false;
		}

		public bool Execute (Card card,Dictionary<string, string> parameters)
		{
			card.SetLocation(LOCATION.Battlefield);
			return true;
		}

	}
}

