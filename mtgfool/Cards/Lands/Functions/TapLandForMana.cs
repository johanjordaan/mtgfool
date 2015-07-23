﻿using System;
using System.Collections.Generic;
using mtgfool.Objects;
using mtgfool.Base;
using mtgfool.Cards;

namespace mtgfool
{
	public class TapLandForMana:BaseFunction
	{
		public override bool CanExecute (IContext context,Dictionary<string, string> parameters)
		{
			var card = context as Card;

			var target = parameters["target"];
			COLOR color;
			Enum.TryParse<COLOR>(parameters["color"],out color);

			if (card.Location != LOCATION.Battlefield)
				return false;
			if (card.Id != target)
				return false;
			if (card.Tapped)
				return false;

			return true;
		}

		public override bool Execute (IContext context,Dictionary<string, string> parameters)
		{
			var card = context as Card;
			COLOR color;
			Enum.TryParse<COLOR>(parameters["color"],out color);
			card.Player.ManaPool.Add (color,1);
			card.Tap ();

			Console.Out.WriteLine ("---[{0}] has [{1}]R in their manapool",card.Player.Name,card.Player.ManaPool[color]);
			return true;
		}

		public TapLandForMana(ParameterList<IContext> extraParameters):base(extraParameters) {
			Func<IContext,List<string>> identitySelector = (context) => {
				var card = context as Card;
				return new List<string> () { card.Id }; 
			};
			parameters.Add(new Parameter<IContext>("target",identitySelector));
		}
		public TapLandForMana():base() {
			Func<IContext,List<string>> identitySelector = (context) => {
				var card = context as Card;
				return new List<string> () { card.Id }; 
			};
			parameters.Add(new Parameter<IContext>("target",identitySelector));
		}

	}
}

