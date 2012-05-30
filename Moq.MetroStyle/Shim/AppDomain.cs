using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace System
{
	public class AppDomain
	{
		public static AppDomain CurrentDomain = new AppDomain();

		private AppDomain()
		{
		}

		internal AssemblyBuilder DefineDynamicAssembly(Reflection.AssemblyName name, AssemblyBuilderAccess access)
		{
			return AssemblyBuilder.DefineDynamicAssembly(name, access);
		}
	}
}
