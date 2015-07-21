using System;

namespace mtgfool.Utils
{
	public class AssertAndThrow
	{
		public static void IsTrue(bool condition) {
			if(condition) 
				throw new Exception();
		}
	}
}

