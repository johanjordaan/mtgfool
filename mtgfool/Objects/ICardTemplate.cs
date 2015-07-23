using System;
using System.Collections.Generic;
using mtgfool.Base;

namespace mtgfool.Objects
{
	public interface ICardTemplate
	{
		string Name { get; }
		Dictionary<string,IFunction<IContext>> Actions { get; }
	}
}

