using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moq.Tests
{
	public class TypeExtenderFoo
	{
		public object PublicInstanceProperty { get; set; }
		protected object ProtectedInstanceProperty { get; set; }
		private object PrivateInstanceProperty { get; set; }

		public static object PublicStaticProperty { get; set; }
		protected static object ProtectedStaticProperty { get; set; }
		private static object PrivateStaticProperty { get; set; }

		public object PublicInstanceField;
		protected object ProtectedInstanceField;
		private object PrivateInstanceField;

		public static object PublicStaticField;
		protected static object ProtectedStaticField;
		private static object PrivateStaticField;

		public event EventHandler PublicInstanceEvent;
		protected event EventHandler ProtectedInstanceEvent;
		private event EventHandler PrivateInstanceEvent;

		public static event EventHandler PublicStaticEvent;
		protected static event EventHandler ProtectedStaticEvent;
		private static event EventHandler PrivateStaticEvent;

		public TypeExtenderFoo()
		{
		}

		public void PublicInstanceMethod()
		{
		}

		protected void ProtectedInstanceMethod()
		{
		}

		private void PrivateInstanceMethod()
		{
		}

		public static void PublicStaticMethod()
		{
		}

		protected static void ProtectedStaticMethod()
		{
		}

		private static void PrivateStaticMethod()
		{
		}

		// @mbrit - 2012-05-31 - this method is to get rid of warnings...
		public void FixWarnings()
		{
			this.PrivateInstanceField = null;
			Debug.WriteLine(this.PrivateInstanceField);

			this.PublicInstanceEvent += Sink;
			this.ProtectedInstanceEvent += Sink;
			this.PrivateInstanceEvent += Sink;

			this.PublicInstanceEvent(null, null);
			this.ProtectedInstanceEvent(null, null);
			this.PrivateInstanceEvent(null, null);
		}

		// @mbrit - 2012-05-31 - this method is to get rid of warnings...
		public static void FixWarningsStatic()
		{
			PrivateStaticField = null;
			Debug.WriteLine(PrivateStaticField);

			PublicStaticEvent += Sink;
			ProtectedStaticEvent += Sink;
			PrivateStaticEvent += Sink;

			PublicStaticEvent(null, null);
			ProtectedStaticEvent(null, null);
			PrivateStaticEvent(null, null);
		}

		private static void Sink(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
