using System;
using System.Collections.Generic;
using mtgfool.Base;
using mtgfool.Core;

namespace mtgfool.Cards
{
	public class PlayLandFromHand:BaseFunction
	{
		public override bool CanExecute (IContext context,Dictionary<string, string> parameters)
		{
			var card = context as Card;

			var target = parameters["target"];

			if (card.Id != target)
				return false;
			if (card.Location != LOCATION.Hand)
				return false;
			if (card.Player != card.Player.Game.ActivePlayer)
				return false;
			if (card.Player.Game.CurrentPhase != PHASE.FirstMain && card.Player.Game.CurrentPhase != PHASE.SecondMain)
				return false;

			return true;
		}

		public override bool Execute (IContext context,Dictionary<string, string> parameters)
		{
			var card = context as Card;
			card.SetLocation(LOCATION.Battlefield);
			return true;
		}

		public PlayLandFromHand(ParameterList<IContext> extraParameters):base(extraParameters) {
			Func<IContext,List<string>> identitySelector = (context) => {
				var card = context as Card;
				return new List<string> () { card.Id }; 
			};
			parameters.Add(new Parameter<IContext>("target",identitySelector));
		}
		public PlayLandFromHand():base() {
			Func<IContext,List<string>> identitySelector = (context) => {
				var card = context as Card;
				return new List<string> () { card.Id }; 
			};
			parameters.Add(new Parameter<IContext>("target",identitySelector));
		}
	}
}

