using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;

namespace System.Reflection
{
	internal static class TypeExtender
	{
		public static Type[] EmptyTypes = { };

		internal static Assembly Assembly(this Type type)
		{
			return type.GetTypeInfo().Assembly;
		}

		internal static bool IsGenericType(this Type type)
		{
			return type.GetTypeInfo().IsGenericType;
		}

		internal static bool IsGenericTypeDefinition(this Type type)
		{
			return type.GetTypeInfo().IsGenericTypeDefinition;
		}

		internal static bool IsAssignableFrom(this Type type, Type toCheck)
		{
			return type.GetTypeInfo().IsAssignableFrom(toCheck.GetTypeInfo());
		}

		internal static bool IsInstanceOf(this Type type, object toCheck)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static bool IsSubclassOf(this Type type, Type toCheck)
		{
			return type.GetTypeInfo().IsSubclassOf(toCheck);
		}

		public static MethodInfo GetMethod(this Type type, string name, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
		{
			foreach (var method in type.GetTypeInfo().DeclaredMethods.Where(v => v.Name == name))
			{
				if (method.CheckBindings(flags))
					return method;
			}

			// not found
			throw new MissingMethodException(string.Format("A method called '{0}' on type '{1}' was not found.", name, type));
		}

		public static MethodInfo GetMethod(this Type type, string name, Type[] parameters)
		{
			return type.GetMethod(name, BindingFlags.Public | BindingFlags.Instance, null, parameters, null);
		}

		public static MethodInfo GetMethod(this Type type, string name, BindingFlags flags, object binder, Type[] parameters, object[] modifiers)
		{
			return type.GetMethod(name, flags, null, CallingConventions.Any, parameters, modifiers);
		}

		public static MethodInfo GetMethod(this Type type, string name, BindingFlags flags, object binder, CallingConventions callConvention, Type[] parameters, object[] modifiers)
		{
			foreach (var method in type.GetTypeInfo().DeclaredMethods.Where(v => v.Name == name))
			{
				if (method.CheckBindings(flags) && CheckParameters(method, parameters))
					return method;
			}

			// not found
			throw new MissingMethodException(string.Format("A method called '{0}' on type '{1}' was not found.", name, type));
		}

		//internal static Assembly GetAssembly(this Type type)
		//{
		//	return type.GetTypeInfo().Assembly();
		//}

		internal static bool IsInterface(this Type type)
		{
			return type.GetTypeInfo().IsInterface;
		}

		internal static bool IsClass(this Type type)
		{
			return type.GetTypeInfo().IsClass;
		}

		internal static bool IsPublic(this Type type)
		{
			return type.GetTypeInfo().IsPublic;
		}

		internal static bool IsArray(this Type type)
		{
			return type.GetTypeInfo().IsArray;
		}

		internal static bool IsEnum(this Type type)
		{
			return type.GetTypeInfo().IsEnum;
		}

		internal static bool IsNestedPublic(this Type type)
		{
			return type.GetTypeInfo().IsNestedPublic;
		}

		internal static bool IsNestedAssembly(this Type type)
		{
			return type.GetTypeInfo().IsNestedAssembly;
		}

		internal static bool IsNestedFamORAssem(this Type type)
		{
			return type.GetTypeInfo().IsNestedFamORAssem;
		}

		internal static bool IsVisible(this Type type)
		{
			return type.GetTypeInfo().IsVisible;
		}

		internal static bool IsAbstract(this Type type)
		{
			return type.GetTypeInfo().IsAbstract;
		}

		internal static bool IsSealed(this Type type)
		{
			return type.GetTypeInfo().IsSealed;
		}

		internal static bool IsPrimitive(this Type type)
		{
			return type.GetTypeInfo().IsPrimitive;
		}

		internal static bool IsValueType(this Type type)
		{
			return type.GetTypeInfo().IsValueType;
		}

		internal static MethodBase DeclaringMethod(this Type type)
		{
			return type.GetTypeInfo().DeclaringMethod;
		}

		internal static Type UnderlyingSystemType(this Type type)
		{
			// @mbrit - 2012-05-30 - this needs more science... UnderlyingSystemType isn't supported
			// in WinRT, but unclear why this was used...
			return type;
		}

		internal static bool ContainsGenericParameters(this Type type)
		{
			return type.GetTypeInfo().ContainsGenericParameters;
		}

		internal static GenericParameterAttributes GenericParameterAttributes(this Type type)
		{
			return type.GetTypeInfo().GenericParameterAttributes;
		}

		internal static Type BaseType(this Type type)
		{
			return type.GetTypeInfo().BaseType;
		}

		internal static Type[] GetInterfaces(this Type type)
		{
			return type.GetTypeInfo().ImplementedInterfaces.ToArray();
		}

		internal static InterfaceMapping GetInterface(this Type type, Type interfaceType)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static object[] GetCustomAttributes(this Type type, bool inherit = false)
		{
			return type.GetTypeInfo().GetCustomAttributes(inherit).ToArray();
		}

		internal static object[] GetCustomAttributes(this Type type, Type attributeType, bool inherit = false)
		{
			return type.GetTypeInfo().GetCustomAttributes(attributeType, inherit).ToArray();
		}

		internal static ConstructorInfo[] GetConstructors(this Type type, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
		{
			// flags are ignored - only public instance members are available in WinRT...
			return type.GetTypeInfo().DeclaredConstructors.ToArray();
		}

		internal static PropertyInfo[] GetProperties(this Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
		{
			return type.GetTypeInfo().DeclaredProperties.ToArray();
		}

		internal static MethodInfo[] GetMethods(this Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
		{
			return type.GetTypeInfo().DeclaredMethods.ToArray();
		}

		internal static FieldInfo[] GetFields(this Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
		{
			return type.GetTypeInfo().DeclaredFields.ToArray();
		}

		internal static EventInfo[] GetEvents(this Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
		{
			return type.GetTypeInfo().DeclaredEvents.ToArray();
		}

		public static FieldInfo GetField(this Type type, string name, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public)
		{
			foreach (var field in type.GetTypeInfo().DeclaredFields.Where(v => v.Name == name))
			{
				if (field.CheckBindings(flags))
					return field;
			}

			throw new MissingMemberException(string.Format("Failed to find field '{0}' on type '{1}'.", name, type));
		}

		public static ConstructorInfo GetConstructor(this Type type, params Type[] types)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		public static ConstructorInfo GetConstructor(this Type type, BindingFlags flags, object binder, Type[] types, object[] modifiers)
		{
			foreach (ConstructorInfo info in type.GetTypeInfo().DeclaredConstructors)
			{
				if (info.CheckBindings(flags) && CheckParameters(info, types))
					return info;
			}

			throw new MissingMemberException("Constructor not found.");
		}

		private static bool CheckParameters(MethodBase method, Type[] parameters)
		{
			var methodParameters = method.GetParameters();
			if (methodParameters.Length == parameters.Length)
			{
				if (parameters.Length == 0)
					return true;
				else
				{
					for (int index = 0; index < parameters.Length; index++)
					{
						if (parameters[index] != methodParameters[index].ParameterType)
							return false;
					}

					// ok...
					return true;
				}
			}

			// nope...
			return false;
		}

		public static PropertyInfo GetProperty(this Type type, string name, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		public static EventInfo GetEvent(this Type type, string name, BindingFlags flags = BindingFlags.Public | BindingFlags.Instance)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		public static Type GetInterface(this Type type, string name, bool ignoreCase = false)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static Type[] GetGenericArguments(this Type type)
		{
			return type.GetTypeInfo().GenericTypeArguments;
		}

		internal static Type[] GetGenericParameterConstraints(this Type type)
		{
			return type.GetTypeInfo().GetGenericParameterConstraints();
		}

		//internal static Type[] FindInterfaces(this Type type, Func<Type, object, bool> filter, object criteria)
		//{
		//	List<Type> results = new List<Type>();
		//	foreach (var iface in type.GetTypeInfo().ImplementedInterfaces)
		//	{
		//		if (filter(iface, criteria))
		//			results.Add(iface);
		//	}

		//	return results.ToArray();
		//}

		internal static object GetCustomAttribute<T>(this Type type, bool inherit = false)
			where T : Attribute
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static InterfaceMapping GetInterfaceMap(this Type type, Type interfaceType)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static TypeCode GetTypeCode(this Type type)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}
	}

	internal static class PropertyInfoExtender
	{
		internal static MethodInfo GetGetMethod(this PropertyInfo prop, bool nonPublic = false)
		{
			// @mbrit - 2012-05-30 - non-public not supported in winrt...
			if (prop.GetMethod.IsPublic || nonPublic)
				return prop.GetMethod;
			else
				return null;
		}

		internal static MethodInfo GetSetMethod(this PropertyInfo prop, bool nonPublic = false)
		{
			// @mbrit - 2012-05-30 - non-public not supported in winrt...
			if (prop.SetMethod.IsPublic || nonPublic)
				return prop.SetMethod;
			else
				return null;
		}

		internal static Type ReflectedType(this PropertyInfo prop)
		{
			// this isn't right...
			return prop.DeclaringType;
		}
	}

	internal static class ParameterInfoExtender
	{
		internal static bool HasAttribute<T>(this ParameterInfo info)
			where T : Attribute
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}
	}

	internal static class MemberInfoExtender
	{
		internal static MemberTypes MemberType(this MemberInfo member)
		{
			if(member is MethodInfo)
				return ((MethodInfo)member).MemberType();
			else
				throw new NotSupportedException(string.Format("Cannot handle '{0}'.", member.GetType()));
		}

		internal static Type ReflectedType(this MemberInfo member)
		{
			// this isn't right...
			if (member is MethodInfo)
				return ((MethodInfo)member).ReflectedType();
			else
				throw new NotSupportedException(string.Format("Cannot handle '{0}'.", member.GetType()));
		}

		internal static bool HasAttribute<T>(this MemberInfo member, bool inherit = false)
			where T : Attribute
		{
			return member.HasAttribute(typeof(T), inherit);
		}

		internal static bool HasAttribute(this MemberInfo member, Type type, bool inherit = false)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}

		internal static bool CheckBindings(this MemberInfo member, BindingFlags flags)
		{
			// TBD...
			return true;
		}
	}

	internal static class MethodInfoExtender
	{
		internal static MemberTypes MemberType(this MethodInfo method)
		{
			return MemberTypes.Method;
		}

		internal static Type ReflectedType(this MethodInfo method)
		{
			// this isn't right...
			return method.DeclaringType;
		}

		internal static MethodInfo GetBaseDefinition(this MethodInfo method)
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}
	}

	internal static class EventInfoExtender
	{
		internal static MethodInfo GetAddMethod(this EventInfo e, bool nonPublic)
		{
			if (e.AddMethod != null || nonPublic)
				return e.AddMethod;
			else
				return null;
		}

		internal static MethodInfo GetRemoveMethod(this EventInfo e, bool nonPublic)
		{
			if (e.RemoveMethod != null || nonPublic)
				return e.RemoveMethod;
			else
				return null;
		}
	}

	internal static class AssemblyExtender
	{
		internal static object[] GetAttributes<T>()
			where T : Attribute
		{
			throw new NotImplementedException("This operation has not been implemented.");
		}
	}
	
	[Flags]
	public enum BindingFlags
	{
		Instance = 4,
		Static = 8,
		Public = 16,
		NonPublic = 32
	}

	[Flags]
	public enum MemberTypes
	{
		Constructor = 1,
		Event = 2,
		Field = 4,
		Method = 8,
		Property = 16
	}

	public enum TypeCode
	{
		Empty = 0,
		Object = 1,
		DBNull = 2,
		Boolean = 3,
		Char = 4,
		SByte = 5,
		Byte = 6,
		Int16 = 7,
		UInt16 = 8,
		Int32 = 9,
		UInt32 = 10,
		Int64 = 11,
		UInt64 = 12,
		Single = 13,
		Double = 14,
		Decimal = 15,
		DateTime = 16,
		String = 18,
	}
}
