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
			Actions.Add ("TapForMana", new TapLandForMana ());


			Func<Card,List<string>> r1 = (card) => new List<string>() { card.Id }; 
			var parameterList = new ParameterList<Card> ();
			parameterList.Add(new Parameter<Card>("target",r1));

			var parameterList2 = new ParameterList<Card> ();
			parameterList2.Add(new Parameter<Card>("target",r1));
			parameterList2.Add(new Parameter<Card>("color",COLOR.Red.ToString()));
		}
	}
}

