using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0API.Domain.Specification.ExpressionSerilization
{
    public interface IExpressionSerializerFactory
    {
        /// <summary>Creates instances of expression serializers.</summary>
        IExpressionSerializer CreateSerializer();
    }
}
