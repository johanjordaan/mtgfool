using System;

namespace mtgfool.Base
{
	public class IdObject
	{
		public string Id { get; private set; }

		public IdObject ()
		{
			Id = Guid.NewGuid().ToString();
		}
	}
}

