using System;
using System.Collections.Generic;

namespace mtgfool.Base
{
	public class Parameter<CONTEXT>
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

		public Parameter (string name,string value)
		{
			Name = name;
			ValueGenerator = (card) => new List<string>() { value }; 
		}

		public Parameter (string name,List<string> values)
		{
			Name = name;
			ValueGenerator = (card) => values; 
		}
	}
}

