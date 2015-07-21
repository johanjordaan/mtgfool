using System;
using mtgfool.Objects;

namespace mtgfool.Cards
{
	public class Mountain:ICardTemplate
	{
		public string Name { get; private set; }

		public Mountain()
		{
			Name = "Mountain";
		}
	}
}

