using NUnit.Framework;
using System;
using System.Collections.Generic;
using mtgfool.Base;

namespace mtgfoolTests.Base
{
	public class SampleContext:mtgfool.Base.IContext
	{
	}

	[TestFixture ()]
	public class ParameterListTests
	{
		[Test ()]
		public void TestExpand ()
		{
			Func<SampleContext,List<string>> r1 = (ctx) => new List<string>() {"1","2","3"}; 
			Func<SampleContext,List<string>> r2 = (ctx) => new List<string>() {"a","b","c","d"}; 
			Func<SampleContext,List<string>> r3 = (ctx) => new List<string>() {"Green","Blue"}; 


			var context = new SampleContext ();
			var parameterList = new ParameterList<SampleContext> ();
			parameterList.Add (new mtgfool.Base.Parameter<SampleContext> ("number",r1));
			parameterList.Add (new mtgfool.Base.Parameter<SampleContext> ("letter",r2));
			parameterList.Add (new mtgfool.Base.Parameter<SampleContext> ("color",r3));

			var x = parameterList.Expand (context);

			Assert.AreEqual (24, x.Count);
			var y = x.FindAll ((d) => d ["number"] == "2" && d ["letter"] == "d" && d ["color"] == "Green");
			Assert.AreEqual	(1, y.Count);

		}
	}
}

