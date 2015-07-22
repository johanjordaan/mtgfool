using System;
using mtgfool.Objects;
using mtgfool.Base;
using System.Collections.Generic;

namespace mtgfool.Cards
{
	public class Mountain:ICardTemplate
	{
		public string Name { get; private set; }

		public Dictionary<string,IFunction<Card>> Actions { get; private set; }
		public Mountain()
		{
			Name = "Mountain";
			Actions = new Dictionary<string, IFunction<Card>> ();

			Actions.Add ("PlayLandFromHand", new PlayLandFromHand ());

		}
	}
}

