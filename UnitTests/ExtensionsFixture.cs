using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETFX_CORE
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using Assert = Moq.Tests.AssertExtender;
#else
using Xunit;
#endif

namespace Moq.Tests
{
#if NETFX_CORE
	[TestClass]
#endif
	public class ExtensionsFixture
	{
		[Fact]
		public void IsMockeableReturnsFalseForValueType()
		{
			Assert.False(typeof(int).IsMockeable());
		}
	}
}
