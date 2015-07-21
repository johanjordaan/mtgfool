using NUnit.Framework;
using System;
using System.Collections.Generic;
using mtgfool.Objects;
using mtgfool.Utils;

namespace mtgfoolTests.Objects
{
	[TestFixture ()]
	public class ManaPoolTests
	{
		[Test ()]
		public void TestConstructor ()
		{
			var manaPool = new ManaPool ();

			foreach (var color in EnumUtil.GetValues<COLOR>()) {
				Assert.AreEqual (0, manaPool [color]);
			}
		}

		[Test()]
		public void TestAdd()
		{
			var manaPool = new ManaPool ();

			manaPool.Add (COLOR.Red, 2);
			manaPool.Add (COLOR.Red, 2);
			manaPool.Add (COLOR.Blue, 3);
			foreach (var color in EnumUtil.GetValues<COLOR>()) {
				switch (color) {
				case COLOR.Red:
					Assert.AreEqual (4, manaPool [color]);
					break;
				case COLOR.Blue:
					Assert.AreEqual (3, manaPool [color]);
					break;
				default:
					Assert.AreEqual (0, manaPool [color]);
					break;
				}					
			}
		}

		[Test()]
		public void TestRemove()
		{
			var manaPool = new ManaPool ();

			manaPool.Add (COLOR.Red, 2);
			manaPool.Add (COLOR.Green, 2);
			manaPool.Add (COLOR.Blue, 3);

			Assert.IsTrue (manaPool.Remove (COLOR.Red, 1));
			Assert.IsFalse (manaPool.Remove (COLOR.Red, 2));
			Assert.AreEqual (1, manaPool [COLOR.Red]);

			Assert.IsFalse (manaPool.Remove (COLOR.White, 1));
			Assert.IsFalse (manaPool.Remove (COLOR.Blue, 4));
		}

		[Test()]
		public void TestClear()
		{
			var manaPool = new ManaPool ();

			manaPool.Add (COLOR.Red, 2);
			manaPool.Add (COLOR.Green, 2);
			manaPool.Add (COLOR.Blue, 3);

			manaPool.Clear ();
			foreach (var color in EnumUtil.GetValues<COLOR>()) {
				Assert.AreEqual (0, manaPool [color]);
			}
		}
	}
}

