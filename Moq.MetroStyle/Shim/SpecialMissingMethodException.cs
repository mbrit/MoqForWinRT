using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq
{
	// @mbrit - 2012-05-31 - special exception to stand-in for the MissingMethodException
	// that's not in WinRT.
	public class SpecialMissingMethodException : Exception
	{
		public SpecialMissingMethodException(string message)
			: base(message)
		{
		}
	}
}
