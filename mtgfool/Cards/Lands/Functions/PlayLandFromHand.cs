﻿using System;
using System.Collections.Generic;
using mtgfool.Base;
using mtgfool.Objects;

namespace mtgfool.Cards
{
	public class PlayLandFromHand:IFunction<Card>
	{
		public bool CanExecute (Card card,Dictionary<string, string> parameters)
		{
			var target = parameters["target"];

			if (card.Location != LOCATION.Hand)
				return false;
			if (card.Id != target)
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

