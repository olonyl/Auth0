using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Specification.ExpressionSerilization
{
    public static class SerializationSettings
    {
        /// <summary>An expression serializer factory.</summary>
        public static IExpressionSerializerFactory ExpressionSerializerFactory { get; set; }
    }
}
