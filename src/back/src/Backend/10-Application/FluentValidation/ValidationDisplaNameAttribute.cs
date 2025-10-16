namespace Application.FluentValidation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ValidationDisplaNameAttribute(string displayName) : Attribute
    {
        public string DisplayName { get; } = displayName;
    }
}
