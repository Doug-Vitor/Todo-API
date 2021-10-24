using System;

namespace TodoApi.Domain.Repositories.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() : base()
        {
        }
    }
}
