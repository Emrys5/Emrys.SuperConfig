using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Emrys.SuperConfig.Strategy;

namespace Emrys.SuperConfig.Mapping.Mappingers
{
    /// <summary>
    /// 实体Mappinger
    /// </summary>
    public class EntityMappinger : BaseMappinger, IMappinger
    {  
        public bool IsCanMapping(Type type)
        {
            return false;
        }

        public object Mapping(XElement element, Type type)
        {
            return SuperConfig.Mapping(type, element, ConvertCaseStrategy);
        }
    }
}
