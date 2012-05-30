using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
	internal static class ListExtender
	{
		internal static void ForEach<T>(this List<T> list, Action<T> callback)
		{
			foreach (T item in list)
				callback(item);
		}
	}
}
