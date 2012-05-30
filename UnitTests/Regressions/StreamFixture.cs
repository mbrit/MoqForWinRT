using System.Diagnostics;
using System.IO;

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
	public class StreamFixture
	{
		[Fact]
		public void ShouldMockStream()
		{
			var mockStream = new Mock<Stream>();

			mockStream.Setup(stream => stream.Seek(0, SeekOrigin.Begin)).Returns(0L);

			var position = mockStream.Object.Seek(0, SeekOrigin.Begin);

			Assert.Equal(0, position);

			mockStream.Setup(stream => stream.Flush());
			mockStream.Setup(stream => stream.SetLength(100));

			mockStream.Object.Flush();
			mockStream.Object.SetLength(100);

			mockStream.VerifyAll();
		}
	}
}
