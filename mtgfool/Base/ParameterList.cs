using System;
using mtgfool.Base;
using System.Collections.Generic;

namespace mtgfool.Base
{
	public class ParameterList<CONTEXT>:IEnumerable<Parameter<CONTEXT>>
	{
		#region IEnumerable implementation

		public IEnumerator<Parameter<CONTEXT>> GetEnumerator ()
		{
			return parameters.GetEnumerator ();
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return parameters.GetEnumerator ();
		}

		#endregion

		

		private List<Parameter<CONTEXT>> parameters = new List<Parameter<CONTEXT>> ();
		public void Add(Parameter<CONTEXT> parameter) {
			parameters.Add (parameter);
		}

		private List<Dictionary<string,string>> expand(CONTEXT context,int parameterIndex,Dictionary<string,string> currentExpansion,List<Dictionary<string,string>> retVal)
		{
			if (parameterIndex >= parameters.Count)
				return retVal;
			var currentParameter = parameters [parameterIndex];

			retVal.Remove (currentExpansion);
			foreach (var currentValue in currentParameter.GetValues(context)) { 
				var nextExpansion = new Dictionary<string,string> (currentExpansion);
				nextExpansion.Add (currentParameter.Name, currentValue);
				retVal.Add (nextExpansion);
				expand(context,parameterIndex+1,nextExpansion,retVal);
			}

			return retVal;
		}

		public List<Dictionary<string,string>> Expand (CONTEXT context)
		{
			return expand(context,0,new Dictionary<string,string>(),new List<Dictionary<string,string>> ());
		}

		public ParameterList ()
		{
		}
	}
}

