using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace mtgfoolTests.Base
{
	public class SampleContext:mtgfool.Base.IContext
	{
	}

	public class SampleFunction:mtgfool.Base.Function<SampleContext>
	{
		#region implemented abstract members of Function
		public override bool CanExecute (System.Collections.Generic.Dictionary<string, string> parameters)
		{
			throw new NotImplementedException ();
		}
		public override bool Execute (System.Collections.Generic.Dictionary<string, string> parameters)
		{
			throw new NotImplementedException ();
		}
		#endregion

		public SampleFunction(SampleContext context,List<mtgfool.Base.Parameter<SampleContext>> parameters):base(context,parameters)
		{
		}
	}

	[TestFixture ()]
	public class FunctionTests
	{
		[Test ()]
		public void TestExpand ()
		{
			Func<SampleContext,List<string>> r1 = (ctx) => new List<string>() {"1","2","3"}; 
			Func<SampleContext,List<string>> r2 = (ctx => new List<string>() {"a","b","c","d"}; 
			Func<SampleContext,List<string>> r3 = (ctx) => new List<string>() {"Green","Blue"}; 


			var context = new SampleContext ();
			var parameters = new List<mtgfool.Base.Parameter<SampleContext>> ();
			parameters.Add (new mtgfool.Base.Parameter<SampleContext> ("number",r1));
			parameters.Add (new mtgfool.Base.Parameter<SampleContext> ("letter",r2));
			parameters.Add (new mtgfool.Base.Parameter<SampleContext> ("color",r3));
			var function = new SampleFunction (context,parameters);
			var x = function.Expand ();

			Assert.AreEqual (24, x.Count);
			var y = x.FindAll ((d) => d ["number"] == "2" && d ["letter"] == "d" && d ["color"] == "Green");
			Assert.AreEqual	(1, y.Count);

		}
	}
}

