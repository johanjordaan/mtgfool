using System;

namespace mtgfool.Utils
{
	public class IdObject
	{
		public string Id { get; private set; }

		public IdObject ()
		{
			Id = Guid.NewGuid ().ToString ("N");
		}
	}
}

