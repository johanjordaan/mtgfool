﻿using System;
using System.Collections.Generic;

namespace mtgfool.Base
{
	public interface IFunction<CONTEXT> where CONTEXT:IContext
	{
		bool CanExecute (CONTEXT context, Dictionary<string,string> parameters);
		bool Execute (CONTEXT contextm, Dictionary<string,string> parameters);
	}
}

