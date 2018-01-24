namespace Emrys.SuperConfig.Mapping
{
    public interface ITypeMapping
    {
        void Apply(object instance);
        void Add(IPropertyMapping propertyMapping);
    }
}