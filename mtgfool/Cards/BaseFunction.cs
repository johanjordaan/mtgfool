using System;
using mtgfool.Base;
using mtgfool.Objects;
using System.Collections.Generic;

namespace mtgfool.Cards
{
	public abstract class BaseFunction:IFunction<IContext>
	{
		public ParameterList<IContext> GetParameters() {
			return parameters;
		}

		public abstract bool CanExecute (IContext context, Dictionary<string, string> parameters);
		public abstract bool Execute (IContext context, Dictionary<string, string> parameters);


		protected ParameterList<IContext> parameters = new ParameterList<IContext>();
		private void init(ParameterList<IContext> extraParameters) 
		{
			if (extraParameters != null) {
				foreach (var parameter in extraParameters) {
					parameters.Add (parameter);
				}
			}
		}

		public BaseFunction(ParameterList<IContext> extraParameters) {
			init (extraParameters);
		}
		public BaseFunction() {
			init (null);
		}
	}
}

