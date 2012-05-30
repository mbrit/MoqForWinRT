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
	public class MockSequenceFixture
	{
		[Fact]
		public void RightSequenceSuccess()
		{
			var a = new Mock<IFoo>(MockBehavior.Strict);
			var b = new Mock<IFoo>(MockBehavior.Strict);

			var sequence = new MockSequence();
			a.InSequence(sequence).Setup(x => x.Do(100)).Returns(101);
			b.InSequence(sequence).Setup(x => x.Do(200)).Returns(201);

			a.Object.Do(100);
			b.Object.Do(200);
		}

		[Fact]
		public void InvalidSequenceFail()
		{
			var a = new Mock<IFoo>(MockBehavior.Strict);
			var b = new Mock<IFoo>(MockBehavior.Strict);

			var sequence = new MockSequence();
			a.InSequence(sequence).Setup(x => x.Do(100)).Returns(101);
			b.InSequence(sequence).Setup(x => x.Do(200)).Returns(201);

			Assert.Throws<MockException>(() => b.Object.Do(200));
		}

		[Fact]
		public void NoCyclicSequenceFail()
		{
			var a = new Mock<IFoo>(MockBehavior.Strict);
			var b = new Mock<IFoo>(MockBehavior.Strict);

			var sequence = new MockSequence();
			a.InSequence(sequence).Setup(x => x.Do(100)).Returns(101);
			b.InSequence(sequence).Setup(x => x.Do(200)).Returns(201);

			Assert.Equal(101, a.Object.Do(100));
			Assert.Equal(201, b.Object.Do(200));

			Assert.Throws<MockException>(() => a.Object.Do(100));
			Assert.Throws<MockException>(() => b.Object.Do(200));
		}

		[Fact]
		public void CyclicSequenceSuccesss()
		{
			var a = new Mock<IFoo>(MockBehavior.Strict);
			var b = new Mock<IFoo>(MockBehavior.Strict);

			var sequence = new MockSequence { Cyclic = true };
			a.InSequence(sequence).Setup(x => x.Do(100)).Returns(101);
			b.InSequence(sequence).Setup(x => x.Do(200)).Returns(201);

			Assert.Equal(101, a.Object.Do(100));
			Assert.Equal(201, b.Object.Do(200));

			Assert.Equal(101, a.Object.Do(100));
			Assert.Equal(201, b.Object.Do(200));

			Assert.Equal(101, a.Object.Do(100));
			Assert.Equal(201, b.Object.Do(200));
		}

		public interface IFoo
		{
			int Do(int arg);
		}
	}
}