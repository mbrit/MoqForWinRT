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
		internal static MethodInfo Method<T>(this Func<T> func)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static MethodInfo Method<T>(this Expression<T> func)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static MethodInfo Method<T>(this Action<T> func)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static MethodInfo Method(this Delegate d)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}
	}
}
