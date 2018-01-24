using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Mapping
{
    public interface IPropertyMapping
    {
        void Apply(object instance);
    }
}
