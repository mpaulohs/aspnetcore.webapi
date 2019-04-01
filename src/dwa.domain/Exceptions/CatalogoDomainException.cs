using System;

namespace dwa.domain.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class CatalogoDomainException : Exception
    {
        public CatalogoDomainException()
        { }

        public CatalogoDomainException(string message)
            : base(message)
        { }

        public CatalogoDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
