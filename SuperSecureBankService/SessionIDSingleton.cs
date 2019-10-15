using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperSecureBankService
{
	public class SessionIDSingleton
	{
		Int64 currentID = 0;
		static readonly SessionIDSingleton instance = new SessionIDSingleton();

		// Explicit static constructor to tell C# compiler
		// not to mark type as beforefieldinit
		static SessionIDSingleton()
		{
		}

		SessionIDSingleton()
		{
		}

		public static SessionIDSingleton Instance
		{
			get
			{
				return instance;
			}
		}

		public Int64 NextSessionID
		{
			get
			{
				Random rnd = new Random(DateTime.Now.Millisecond);
				int currentID = rnd.Next(0, 3000);
				return currentID;
			}
		}
	}
}