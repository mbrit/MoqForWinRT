using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Moq.Tests
{
	[TestClass]
	public class TypeExtenderTests
	{
		[TestMethod]
		public void TestGetPublicInstanceMethod()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetMethod("PublicInstanceMethod", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedInstanceMethod()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetMethod("ProtectedInstanceMethod", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateInstanceMethod()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetMethod("PrivateInstanceMethod", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstanceMethodDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetMethod("PublicInstanceMethod", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedInstanceMethodDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetMethod("ProtectedInstanceMethod", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateInstanceMethodDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetMethod("PrivateInstanceMethod", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticMethod()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetMethod("PublicStaticMethod", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedStaticMethod()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetMethod("ProtectedStaticMethod", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateStaticMethod()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetMethod("PrivateStaticMethod", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticMethodDoesntMatchStatice()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetMethod("PublicStaticMethod", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedStaticMethodDoesntMatchStatice()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetMethod("ProtectedStaticMethod", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateStaticMethodDoesntMatchStatice()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetMethod("PrivateStaticMethod", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstanceProperty()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetProperty("PublicInstanceProperty", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedInstanceProperty()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetProperty("ProtectedInstanceProperty", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateInstanceProperty()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetProperty("PrivateInstanceProperty", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstancePropertyDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetProperty("PublicInstanceProperty", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedInstancePropertyDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetProperty("ProtectedInstanceProperty", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateInstancePropertyDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetProperty("PrivateInstanceProperty", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticProperty()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetProperty("PublicStaticProperty", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedStaticProperty()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetProperty("ProtectedStaticProperty", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateStaticProperty()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetProperty("PrivateStaticProperty", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticPropertyDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetProperty("PublicStaticProperty", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedStaticPropertyDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetProperty("ProtectedStaticProperty", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateStaticPropertyDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetProperty("PrivateStaticProperty", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstanceField()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetField("PublicInstanceField", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedInstanceField()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetField("ProtectedInstanceField", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateInstanceField()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetField("PrivateInstanceField", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstanceFieldDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetField("PublicInstanceField", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedInstanceFieldDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetField("ProtectedInstanceField", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateInstanceFieldDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetField("PrivateInstanceField", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticField()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetField("PublicStaticField", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedStaticField()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetField("ProtectedStaticField", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateStaticField()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetField("PrivateStaticField", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticFieldDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetField("PublicStaticField", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedStaticFieldDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetField("ProtectedStaticField", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateStaticFieldDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetField("PrivateStaticField", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstanceEvent()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetEvent("PublicInstanceEvent", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedInstanceEvent()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetEvent("ProtectedInstanceEvent", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateInstanceEvent()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetEvent("PrivateInstanceEvent", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPublicInstanceEventDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetEvent("PublicInstanceEvent", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedInstanceEventDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetEvent("ProtectedInstanceEvent", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateInstanceEventDoesntMatchStatic()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetEvent("PrivateInstanceEvent", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticEvent()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetEvent("PublicStaticEvent", BindingFlags.Public | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetProtectedStaticEvent()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetEvent("ProtectedStaticEvent", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPrivateStaticEvent()
		{
			Assert.IsNotNull(typeof(TypeExtenderFoo).GetEvent("PrivateStaticEvent", BindingFlags.NonPublic | BindingFlags.Static));
		}

		[TestMethod]
		public void TestGetPublicStaticEventDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetEvent("PublicStaticEvent", BindingFlags.Public | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetProtectedStaticEventDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetEvent("ProtectedStaticEvent", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod]
		public void TestGetPrivateStaticEventDoesntMatchInstance()
		{
			Assert.IsNull(typeof(TypeExtenderFoo).GetEvent("PrivateStaticEvent", BindingFlags.NonPublic | BindingFlags.Instance));
		}

		[TestMethod()]
		public void TestGetMethodsPublicInstance()
		{
			var methods = typeof(TypeExtenderFoo).GetMethods(BindingFlags.Public | BindingFlags.Instance);

			Assert.IsNotNull(methods.Where(v => v.Name == "PublicInstanceMethod").FirstOrDefault());

			Assert.IsNull(methods.Where(v => v.Name == "ProtectedInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PrivateInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PublicStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "ProtectedStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PrivateStaticMethod").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetMethodsNonPublicInstance()
		{
			var methods = typeof(TypeExtenderFoo).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

			Assert.IsNotNull(methods.Where(v => v.Name == "ProtectedInstanceMethod").FirstOrDefault());
			Assert.IsNotNull(methods.Where(v => v.Name == "PrivateInstanceMethod").FirstOrDefault());

			Assert.IsNull(methods.Where(v => v.Name == "PublicInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PublicStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "ProtectedStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PrivateStaticMethod").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetPropertiesPublicInstance()
		{
			var properties = typeof(TypeExtenderFoo).GetProperties(BindingFlags.Public | BindingFlags.Instance);

			Assert.IsNotNull(properties.Where(v => v.Name == "PublicInstanceProperty").FirstOrDefault());

			Assert.IsNull(properties.Where(v => v.Name == "ProtectedInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PrivateInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PublicStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "ProtectedStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PrivateStaticProperty").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetPropertiessNonPublicInstance()
		{
			var properties = typeof(TypeExtenderFoo).GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

			Assert.IsNotNull(properties.Where(v => v.Name == "ProtectedInstanceProperty").FirstOrDefault());
			Assert.IsNotNull(properties.Where(v => v.Name == "PrivateInstanceProperty").FirstOrDefault());

			Assert.IsNull(properties.Where(v => v.Name == "PublicInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PublicStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "ProtectedStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PrivateStaticProperty").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetFieldsPublicInstance()
		{
			var fields = typeof(TypeExtenderFoo).GetFields(BindingFlags.Public | BindingFlags.Instance);

			Assert.IsNotNull(fields.Where(v => v.Name == "PublicInstanceField").FirstOrDefault());

			Assert.IsNull(fields.Where(v => v.Name == "ProtectedInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PrivateInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PublicStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "ProtectedStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PrivateStaticField").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetFieldsPublicNonPublicInstance()
		{
			var fields = typeof(TypeExtenderFoo).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

			Assert.IsNotNull(fields.Where(v => v.Name == "ProtectedInstanceField").FirstOrDefault());
			Assert.IsNotNull(fields.Where(v => v.Name == "PrivateInstanceField").FirstOrDefault());

			Assert.IsNull(fields.Where(v => v.Name == "PublicInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PublicStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "ProtectedStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PrivateStaticField").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetEventsPublicInstance()
		{
			var evts = typeof(TypeExtenderFoo).GetEvents(BindingFlags.Public | BindingFlags.Instance);

			Assert.IsNotNull(evts.Where(v => v.Name == "PublicInstanceEvent").FirstOrDefault());

			Assert.IsNull(evts.Where(v => v.Name == "ProtectedInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PrivateInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PublicStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "ProtectedStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PrivateStaticEvent").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetEventsPublicNonPublicInstance()
		{
			var evts = typeof(TypeExtenderFoo).GetEvents(BindingFlags.NonPublic | BindingFlags.Instance);

			Assert.IsNotNull(evts.Where(v => v.Name == "ProtectedInstanceEvent").FirstOrDefault());
			Assert.IsNotNull(evts.Where(v => v.Name == "PrivateInstanceEvent").FirstOrDefault());

			Assert.IsNull(evts.Where(v => v.Name == "PublicInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PublicStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "ProtectedStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PrivateStaticEvent").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetMethodsPublicStatic()
		{
			var methods = typeof(TypeExtenderFoo).GetMethods(BindingFlags.Public | BindingFlags.Static);

			Assert.IsNotNull(methods.Where(v => v.Name == "PublicStaticMethod").FirstOrDefault());

			Assert.IsNull(methods.Where(v => v.Name == "ProtectedStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PrivateStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PublicInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "ProtectedInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PrivateInstanceMethod").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetMethodsNonPublicStatic()
		{
			var methods = typeof(TypeExtenderFoo).GetMethods(BindingFlags.NonPublic | BindingFlags.Static);

			Assert.IsNotNull(methods.Where(v => v.Name == "ProtectedStaticMethod").FirstOrDefault());
			Assert.IsNotNull(methods.Where(v => v.Name == "PrivateStaticMethod").FirstOrDefault());

			Assert.IsNull(methods.Where(v => v.Name == "PublicStaticMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PublicInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "ProtectedInstanceMethod").FirstOrDefault());
			Assert.IsNull(methods.Where(v => v.Name == "PrivateInstanceMethod").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetPropertiesPublicStatic()
		{
			var properties = typeof(TypeExtenderFoo).GetProperties(BindingFlags.Public | BindingFlags.Static);

			Assert.IsNotNull(properties.Where(v => v.Name == "PublicStaticProperty").FirstOrDefault());

			Assert.IsNull(properties.Where(v => v.Name == "ProtectedStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PrivateStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PublicInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "ProtectedInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PrivateInstanceProperty").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetPropertiessNonPublicStatic()
		{
			var properties = typeof(TypeExtenderFoo).GetProperties(BindingFlags.NonPublic | BindingFlags.Static);

			Assert.IsNotNull(properties.Where(v => v.Name == "ProtectedStaticProperty").FirstOrDefault());
			Assert.IsNotNull(properties.Where(v => v.Name == "PrivateStaticProperty").FirstOrDefault());

			Assert.IsNull(properties.Where(v => v.Name == "PublicStaticProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PublicInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "ProtectedInstanceProperty").FirstOrDefault());
			Assert.IsNull(properties.Where(v => v.Name == "PrivateInstanceProperty").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetFieldsPublicStatic()
		{
			var fields = typeof(TypeExtenderFoo).GetFields(BindingFlags.Public | BindingFlags.Static);

			Assert.IsNotNull(fields.Where(v => v.Name == "PublicStaticField").FirstOrDefault());

			Assert.IsNull(fields.Where(v => v.Name == "ProtectedStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PrivateStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PublicInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "ProtectedInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PrivateInstanceField").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetFieldsPublicNonPublicStatic()
		{
			var fields = typeof(TypeExtenderFoo).GetFields(BindingFlags.NonPublic | BindingFlags.Static);

			Assert.IsNotNull(fields.Where(v => v.Name == "ProtectedStaticField").FirstOrDefault());
			Assert.IsNotNull(fields.Where(v => v.Name == "PrivateStaticField").FirstOrDefault());

			Assert.IsNull(fields.Where(v => v.Name == "PublicStaticField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PublicInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "ProtectedInstanceField").FirstOrDefault());
			Assert.IsNull(fields.Where(v => v.Name == "PrivateInstanceField").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetEventsPublicStatic()
		{
			var evts = typeof(TypeExtenderFoo).GetEvents(BindingFlags.Public | BindingFlags.Static);

			Assert.IsNotNull(evts.Where(v => v.Name == "PublicStaticEvent").FirstOrDefault());

			Assert.IsNull(evts.Where(v => v.Name == "ProtectedStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PrivateStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PublicInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "ProtectedInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PrivateInstanceEvent").FirstOrDefault());
		}

		[TestMethod()]
		public void TestGetEventsPublicNonPublicStatic()
		{
			var evts = typeof(TypeExtenderFoo).GetEvents(BindingFlags.NonPublic | BindingFlags.Static);

			Assert.IsNotNull(evts.Where(v => v.Name == "ProtectedStaticEvent").FirstOrDefault());
			Assert.IsNotNull(evts.Where(v => v.Name == "PrivateStaticEvent").FirstOrDefault());

			Assert.IsNull(evts.Where(v => v.Name == "PublicStaticEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PublicInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "ProtectedInstanceEvent").FirstOrDefault());
			Assert.IsNull(evts.Where(v => v.Name == "PrivateInstanceEvent").FirstOrDefault());
		}
	}
}
