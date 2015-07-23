using System;
using mtgfool.Objects;
using mtgfool.Base;
using System.Collections.Generic;

namespace mtgfool.Cards
{
	public class Mountain:ICardTemplate
	{
		public string Name { get; private set; }
		public Dictionary<string,IFunction<IContext>> Actions { get; private set; }

		public Mountain()
		{
			Name = "Mountain";
			Actions = new Dictionary<string, IFunction<IContext>> ();

			var parameterList2 = new ParameterList<IContext> ();
			parameterList2.Add(new Parameter<IContext>("color",COLOR.Red.ToString()));

			Actions.Add ("PlayLandFromHand", new PlayLandFromHand ());
			Actions.Add ("TapForMana", new TapLandForMana (parameterList2));
		}
	}
}

