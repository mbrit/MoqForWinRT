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

namespace Moq.Tests.Linq
{
#if NETFX_CORE
	[TestClass]
#endif
	public class MockRepositoryQuerying
	{
		public class GivenAStrictFactory
		{
			private MockRepository repository;

			public GivenAStrictFactory()
			{
				this.repository = new MockRepository(MockBehavior.Strict);
			}

			[Fact]
			public void WhenQueryingSingle_ThenItIsStrict()
			{
				var foo = this.repository.OneOf<IFoo>();

				Assert.Throws<MockException>(() => foo.Do());
			}

			[Fact]
			public void WhenQueryingMultiple_ThenItIsStrict()
			{
				var foo = this.repository.Of<IFoo>().First();

				Assert.Throws<MockException>(() => foo.Do());
			}

			[Fact]
			public void WhenQueryingSingleWithProperty_ThenItIsStrict()
			{
				var foo = this.repository.OneOf<IFoo>(x => x.Id == "1");

				Assert.Throws<MockException>(() => foo.Do());

				Mock.Get(foo).Verify();

				Assert.Equal("1", foo.Id);
			}

			[Fact]
			public void WhenQueryingMultipleWithProperty_ThenItIsStrict()
			{
				var foo = this.repository.Of<IFoo>(x => x.Id == "1").First();

				Assert.Throws<MockException>(() => foo.Do());

				Mock.Get(foo).Verify();

				Assert.Equal("1", foo.Id);
			}
		}

		public interface IFoo
		{
			string Id { get; set; }
			bool Do();
		}
	}
}
