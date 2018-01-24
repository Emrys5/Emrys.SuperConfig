using Emrys.SuperConfig.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Mapping.Mappingers
{
    public class BaseMappinger
    {
        public IConvertCaseStrategy ConvertCaseStrategy { get; set; }
    }
}
