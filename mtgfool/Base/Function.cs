using System;
using System.Collections.Generic;

namespace mtgfool.Base
{
	public abstract class Function<CONTEXT> : IFunction where CONTEXT:IContext
	{
		#region IFunction implementation
		private List<Dictionary<string,string>> expand(int parameterIndex,Dictionary<string,string> currentExpansion,List<Dictionary<string,string>> retVal)
		{
			if (parameterIndex >= Parameters.Count)
				return retVal;
			var currentParameter = Parameters [parameterIndex];

			retVal.Remove (currentExpansion);
			foreach (var currentValue in currentParameter.GetValues(Context)) { 
				var nextExpansion = new Dictionary<string,string> (currentExpansion);
				nextExpansion.Add (currentParameter.Name, currentValue);
				retVal.Add (nextExpansion);
				expand(parameterIndex+1,nextExpansion,retVal);
			}

			return retVal;
		}

		public List<Dictionary<string,string>> Expand ()
		{
			return expand(0,new Dictionary<string,string>(),new List<Dictionary<string,string>> ());
		}


		abstract public bool CanExecute (Dictionary<string,string> parameters);
		abstract public bool Execute (Dictionary<string,string> parameters);

		#endregion

		public CONTEXT Context { get; private set; }
		public List<Parameter<CONTEXT>> Parameters { get; private set; }

		public Function (CONTEXT context,List<Parameter<CONTEXT>> parameters)
		{
			Context = context;
			Parameters = parameters;
		}
	}
}

