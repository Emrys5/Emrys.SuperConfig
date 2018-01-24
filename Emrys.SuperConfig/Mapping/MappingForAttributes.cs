using Emrys.SuperConfig.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Mapping
{
    public class MappingForAttributes : IPropertyMapping
    {

        readonly XAttribute _attribute;
        readonly PropertyInfo _property;

        public MappingForAttributes(XAttribute attribute, PropertyInfo property)
        {
            _attribute = attribute;
            _property = property;
        }
        public void Apply(object instance)
        {
            try
            {
                var value = TypeDescriptor.GetConverter(_property.PropertyType).ConvertFromInvariantString(_attribute.Value);
                _property.SetValue(instance, value, null);
            }
            catch (Exception ex)
            {
                string msg = $"转换失败，attribute：{_attribute.Name.LocalName}，value：{_attribute.Value}。在类型：{instance.GetType()}属性：{_property.Name}。更多详情请参考inner exception.";
                throw new SuperConfigException(msg, ex);
            }
        }
    }
}
