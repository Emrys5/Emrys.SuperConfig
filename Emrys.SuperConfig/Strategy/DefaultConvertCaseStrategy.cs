using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Strategy
{
    public class DefaultConvertCaseStrategy : IConvertCaseStrategy
    {
        public string ConvertCase(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "";
            }
            return name.Substring(0, 1).ToLower() + name.Substring(1);
        }
    }
}
