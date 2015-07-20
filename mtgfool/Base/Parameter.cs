using System;
using System.Collections.Generic;

namespace mtgfool.Base
{
	public class Parameter<CONTEXT> where CONTEXT:IContext
	{
		public string Name { get; private set; }
		public Func<CONTEXT,List<string>> ValueGenerator { get; private set; }

		public List<string> GetValues(CONTEXT context)
		{
			return ValueGenerator (context);
		}

		public Parameter (string name,Func<CONTEXT,List<string>> valueGenerator)
		{
			Name = name;
			ValueGenerator = valueGenerator;
		}
	}
}

