using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Auth0API.Domain.Specification.ExpressionSerilization
{
    public interface IExpressionSerializer
    {
        /// <summary>Serializes a specified expression to a byte array.</summary>
        byte[] Serialize(Expression expression);

        /// <summary>Deserializes an expression from a specified byte array.</summary>
        Expression Deserialize(byte[] data);
    }
}
