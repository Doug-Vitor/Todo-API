using System;
using Xunit;

namespace TodoApi.UnitTests.Infrastructure.EntityHelper
{
    public class EnsureValueNotNullTests
    {
        public EnsureValueNotNullTests()
        {
        }

        public void GivenNullValueShouldThrowArgumentNullException() => 
            Assert.Throws<ArgumentNullException>(() => TodoApi.Infrastructure.Data.Helpers.EntityHelper.EnsureNotNull(value: null));
    }
}
