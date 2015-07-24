using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace mtgfool.Core
{
	public class CardFactory
	{
		private static Dictionary<string,ICardTemplate> cardTemplates = new Dictionary<string, ICardTemplate>();

		static CardFactory()
		{
			var cardTemplateTypes = Assembly.GetExecutingAssembly().GetTypes()
				.Where((t)=>t.GetInterfaces().Contains(typeof(ICardTemplate))&&t.Namespace=="mtgfool.Cards").ToArray();
				
			foreach (var cardTemplateType in cardTemplateTypes) {
				var cardTemplate = Activator.CreateInstance(cardTemplateType) as ICardTemplate;
				cardTemplates.Add (cardTemplate.Name, cardTemplate);
			}
		}
			
		public static Card GetInstance(string name, Player player)
		{
			return new Card(cardTemplates[name],player,player.Game);
		}
	}
}

