using System;
using System.Collections.Generic;

namespace mtgfool.Base
{
	public interface IFunction
	{
		List<Dictionary<string,string>> Expand ();
		bool CanExecute (Dictionary<string,string> parameters);
		bool Execute (Dictionary<string,string> parameters);
	}
}

