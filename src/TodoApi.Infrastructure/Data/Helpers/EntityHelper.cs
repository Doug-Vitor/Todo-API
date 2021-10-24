using System;

namespace TodoApi.Infrastructure.Data.Helpers
{
    public static class EntityHelper
    {
        public static void EnsureNotNull(int? value)
        {
            if (value is null)
                throw new ArgumentNullException();
        }

        public static void EnsureNotNull(object entity)
        {
            if (entity is null)
                throw new ArgumentNullException();
        }
    }
}
