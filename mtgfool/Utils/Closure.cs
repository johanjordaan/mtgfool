using System;
using System.Collections.Generic;
using mtgfool.Utils;

namespace mtgfool.Utils
{
	public class Closure	
	{
		public bool Execute()
		{
			return function.Execute (context, parameters);
		}

		private IFunction<IContext> function;
		private IContext context;
		private Dictionary<string,string> parameters;
		public Closure (IFunction<IContext> function,IContext context,Dictionary<string,string> parameters)
		{
			this.function = function;
			this.context = context;
			this.parameters = parameters;
		}
	}
}

