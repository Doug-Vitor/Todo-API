using System;
using Xunit;

namespace TodoApi.UnitTests.Infrastructure.EntityHelper
{
    public class EnsureObjectNotNullTests
    {
        public EnsureObjectNotNullTests()
        {
        }

        [Fact]
        public void GivenNullObjectMustThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => TodoApi.Infrastructure.Data.Helpers.EntityHelper.EnsureNotNull(entity: null));
    }
}
