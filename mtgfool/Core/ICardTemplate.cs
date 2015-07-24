using System;
using System.Collections.Generic;
using mtgfool.Utils;

namespace mtgfool.Core
{
	public interface ICardTemplate
	{
		string Name { get; }
		Dictionary<string,IFunction<IContext>> Actions { get; }
	}
}

