using System.Linq.Expressions;
using System.Reflection;

namespace Application.FluentValidation
{
    public static class CustomDisplayNameResolver
    {
        public static string? Resolve(Type type, MemberInfo memberInfo, LambdaExpression expression)
        {
            if (memberInfo != null)
            {
                if (
                    memberInfo
                        .GetCustomAttributes(typeof(ValidationDisplaNameAttribute), false)
                        .FirstOrDefault()
                    is ValidationDisplaNameAttribute displaNameAttribute
                )
                {
                    return displaNameAttribute.DisplayName;
                }
                return memberInfo.Name;
            }
            return null;
        }
    }
}
