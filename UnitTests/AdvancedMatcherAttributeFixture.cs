﻿using System;
using System.Linq.Expressions;

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
	public class AdvancedMatcherAttributeFixture
	{	
		[Fact]
		public void ShouldThrowIfNullMatcherType()
		{
			Assert.Throws<ArgumentNullException>(() => new AdvancedMatcherAttribute(null));
		}

		[Fact]
		public void ShouldThrowIfMatcherNotIExpressionMatcher()
		{
			Assert.Throws<ArgumentException>(() => new AdvancedMatcherAttribute(typeof(object)));
		}

		[Fact]
		public void ShouldCreateMatcher()
		{
			var attr = new AdvancedMatcherAttribute(typeof(MockMatcher));
			var matcher = attr.CreateMatcher();

			Assert.NotNull(matcher);
		}

		[Fact]
		public void ShouldExposeMatcherType()
		{
			var attr = new AdvancedMatcherAttribute(typeof(MockMatcher));

			Assert.Equal(typeof(MockMatcher), attr.MatcherType);
		}

		[Fact]
		public void ShouldThrowRealException()
		{
			var attr = new AdvancedMatcherAttribute(typeof(ThrowingMatcher));
			Assert.Throws<ArgumentException>(() => attr.CreateMatcher());
		}

		public class MockMatcher : IMatcher
		{
			#region IMatcher Members

			public void Initialize(Expression matcherExpression)
			{
			}

			public bool Matches(object value)
			{
				return false;
			}

			#endregion
		}

		public class ThrowingMatcher : IMatcher
		{
			public ThrowingMatcher()
			{
				throw new ArgumentException();
			}

			public void Initialize(Expression matcherExpression)
			{
			}

			public bool Matches(object value)
			{
				return false;
			}
		}
	}
}