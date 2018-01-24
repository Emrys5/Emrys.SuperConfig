using Emrys.SuperConfig.Exceptions;
using Emrys.SuperConfig.Mapping.Mappingers;
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
    public class MappingForElement : IPropertyMapping
    {

        private readonly XElement _element;
        private readonly PropertyInfo _property;
        private readonly IMappinger _mappinger;

        public MappingForElement(XElement element, PropertyInfo property, IMappinger mappinger)
        {
            _element = element;
            _property = property;
            _mappinger = mappinger;
        }
        public void Apply(object instance)
        {
            try
            {
                var value = _mappinger.Mapping(_element, _property.PropertyType);
                _property.SetValue(instance, value, null);
            }
            catch (Exception ex)
            {
                string msg = $"转换失败，element：{_element.Name.LocalName}，value：{_element.Value}。在类型：{instance.GetType()}属性：{_property.Name}。更多详情请参考inner exception.";
                throw new SuperConfigException(msg, ex);
            }
        }
    }
}
