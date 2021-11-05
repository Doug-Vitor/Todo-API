using System;
using Xunit;

namespace TodoApi.UnitTests.Infrastructure.EntityHelper
{
    public class EnsureValueNotNullTests
    {
        public EnsureValueNotNullTests()
        {
        }

        public void GivenNullValueMustThrowArgumentNullException() => 
            Assert.Throws<ArgumentNullException>(() => TodoApi.Infrastructure.Data.Helpers.EntityHelper.EnsureNotNull(value: null));
    }
}
