using NUnit.Framework;
using System;
using System.Collections.Generic;
using mtgfool.Utils;

namespace mtgfoolTests.Utils
{
	class Observer
	{
		public string Status { get; set; }
	}


	[TestFixture ()]
	public class PublisherTests
	{
		[Test ()]
		public void Test ()
		{
			var o = new Observer () { Status = "None" };
			EventHub.AddObserver ("end_of_turn", (context, data) => o.Status = "Signalled" );
			EventHub.Signal ("end_of_turn",null,null);

			Assert.AreEqual ("Signalled", o.Status);
		}
	}
}



