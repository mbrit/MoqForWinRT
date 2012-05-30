using System;

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
	public class SequenceExtensionsFixture
	{
		[Fact]
		public void PerformSequence()
		{
			var mock = new Mock<IFoo>();

			mock.SetupSequence(x => x.Do())
				.Returns(2)
				.Returns(3)
				.Throws<InvalidOperationException>();

			Assert.Equal(2, mock.Object.Do());
			Assert.Equal(3, mock.Object.Do());
			Assert.Throws<InvalidOperationException>(() => mock.Object.Do());
		}

		[Fact]
		public void PerformSequenceOnProperty()
		{
			var mock = new Mock<IFoo>();

			mock.SetupSequence(x => x.Value)
				.Returns("foo")
				.Returns("bar")

#if !NETFX_CORE
				.Throws<SystemException>();
#else
				.Throws<Exception>();
#endif

			string temp;
			Assert.Equal("foo", mock.Object.Value);
			Assert.Equal("bar", mock.Object.Value);

#if !NETFX_CORE
			Assert.Throws<SystemException>(() => temp = mock.Object.Value);
#else
			Assert.Throws<Exception>(() => temp = mock.Object.Value);
#endif
		}

		public interface IFoo
		{
			string Value { get; set; }
			int Do();
		}
	}
}