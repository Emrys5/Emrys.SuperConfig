using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Mapping
{
    public class TypeMapping : ITypeMapping
    {
        private readonly List<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public void Add(IPropertyMapping propertyMapping)
        {
            _propertyMappings.Add(propertyMapping);
        }

        public void Apply(object instance)
        {
            _propertyMappings.ForEach(mapping => mapping.Apply(instance));
        }
    }
}
