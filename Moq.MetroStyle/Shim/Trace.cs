using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Diagnostics
{
	public class Trace
	{
		internal static void Assert(bool result, string message = "Failed.")
		{
			if (!(result))
				throw new InvalidOperationException(message);
		}
	}
}
