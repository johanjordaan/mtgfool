using System;

namespace mtgfool
{
	public class ParameterInstance
	{
		public string Name { get; private set; }
		public string Value { get; private set; }

		public ParameterInstance (string name,string value)
		{
			Name = name;
			Value = value;
		}
	}
}

