using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
	internal static class LinqExtender
	{
		internal static MethodInfo Method(this Delegate d)
		{
			// @mbrit - 2012-05-30 - this will likely fail store validation...
			var info = d.GetType().GetProperty("Method", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			return (MethodInfo)info.GetValue(d);
		}
	}
}
