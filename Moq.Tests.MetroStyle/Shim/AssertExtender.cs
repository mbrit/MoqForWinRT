using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moq.Tests
{
	internal static class AssertExtender
	{
		internal static T Throws<T>(Action callback)
			where T : Exception
		{
			return Throws<T>("Failed.", callback);
		}

		internal static T Throws<T>(string message, Action callback)
			where T : Exception
		{
			try
			{
				callback();

				// nothing happened...
				throw new InvalidOperationException(string.Format("No exception thrown - was expecting '{0}'.", typeof(T)));
			}
			catch (Exception ex)
			{
				if (!(typeof(T).GetTypeInfo().IsAssignableFrom(ex.GetType().GetTypeInfo())))
					throw new InvalidOperationException(string.Format("Exception thrown was '{0}', was expecting '{1}'.", ex.GetType(), typeof(T)));

				return (T)ex;
			}
		}

		internal static void Equal(object a, object b)
		{
			Assert.AreEqual(a, b);
		}

		internal static void NotEqual(object a, object b)
		{
			Assert.AreNotEqual(a, b);
		}

		internal static void Null(object a)
		{
			Assert.IsNull(a);
		}

		internal static void NotNull(object a)
		{
			Assert.IsNotNull(a);
		}

		internal static void Contains(string a, string b)
		{
			Assert.AreNotEqual(-1, b.IndexOf(a));
		}

		internal static void True(bool result)
		{
			Assert.IsTrue(result);
		}

		internal static void True(bool result, string message)
		{
			Assert.IsTrue(result, message);
		}

		internal static void False(bool result)
		{
			Assert.IsFalse(result);
		}

		internal static void Same(object a, object b)
		{
			Assert.AreSame(a, b);
		}

		internal static void IsAssignableFrom<T1>(object value)
		{
			throw new NotImplementedException();
		}

		internal static void DoesNotThrow(Action callback)
		{
			callback();
		}
	}
}
