using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vivo_Task.Shared_Static_Class.Converters;

public static class OrderByStringProperty
{
    public static IEnumerable<TEntity> OrderBy<TEntity>(this IEnumerable<TEntity> source, string orderByProperty,
                          bool desc)
    {

        string command = desc ? "OrderByDescending" : "OrderBy";
        var type = typeof(TEntity);

        var parameter = Expression.Parameter(type, "p");

        // Split the property name by '.' to handle nested properties
        var properties = orderByProperty.Split('.');

        // Create an expression for each property in the chain
        Expression propertyAccess = parameter;
        PropertyInfo? propertyInfo = null;
        foreach (var property in properties)
        {
            propertyInfo = type.GetProperty(property);
            propertyAccess = Expression.MakeMemberAccess(propertyAccess, propertyInfo);
            type = propertyInfo.PropertyType;
        }

        var orderByExpression = Expression.Lambda(propertyAccess, parameter);


        if (propertyInfo == null)
        {
            throw new ArgumentException("Property not found.", nameof(orderByProperty));
        }

        var orderByMethod = typeof(Enumerable).GetMethods()
            .Where(m => m.Name == command)
            .Single(m => m.GetParameters().Length == 2);

        var genericMethod = orderByMethod.MakeGenericMethod(typeof(TEntity), propertyInfo.PropertyType);
        var orderByExpressionCompiled = orderByExpression.Compile();
        var result = genericMethod.Invoke(null, new object[] { source, orderByExpressionCompiled });
        return (IEnumerable<TEntity>)result;
    }
}
