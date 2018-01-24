using Emrys.SuperConfig.Mapping.Mappingers;
using Emrys.SuperConfig.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Mapping
{
    public class MappingFactory
    {
        public static ITypeMapping CreateMapping(Type type, XElement element, IConvertCaseStrategy convertCaseStrategy)
        {

            var elementList = element.Elements().ToList();
            var attributeList = element.Attributes().ToList();

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanWrite && p.GetSetMethod(true).IsPublic).ToList();

            ITypeMapping typeMapping = new TypeMapping();

            foreach (var item in properties)
            {

                var xName = convertCaseStrategy.ConvertCase(item.Name);

                var attribute = attributeList.Where(i => i.Name == xName).FirstOrDefault();
                if (attribute != null)
                {
                    var mappingAttributes = new MappingForAttributes(attribute, item);
                    typeMapping.Add(mappingAttributes);
                    continue;
                }

                var ele = elementList.Where(i => i.Name == xName).FirstOrDefault();
                if (ele != null)
                {
                    var mappinger = MappingerSelector.Get(item.PropertyType, convertCaseStrategy);
                    var mappingElement = new MappingForElement(ele, item, mappinger);
                    typeMapping.Add(mappingElement);
                }
            }

            return typeMapping;

        }
    }
}
