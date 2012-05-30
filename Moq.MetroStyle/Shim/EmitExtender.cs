using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Reflection.Emit
{
	internal static class GenericTypeParameterBuilderExtender
	{
		internal static Type[] AsTypes(this GenericTypeParameterBuilder[] typeParams)
		{
			List<Type> results = new List<Type>();
			foreach (var typeParam in typeParams)
				results.Add(typeParam.AsType());

			return results.ToArray();
		}

		internal static MethodImplAttributes GetMethodImplementationFlags(this ConstructorBuilder builder)
		{
			return builder.MethodImplementationFlags;
		}

		internal static MethodImplAttributes GetMethodImplementationFlags(this MethodBuilder builder)
		{
			return builder.MethodImplementationFlags;
		}
	}
}
