using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Strategy
{
    public class DefaultSuperConfigStrategy : ISuperConfigStrategy
    {
        private readonly IConvertCaseStrategy _convertCaseStrategy;

        public DefaultSuperConfigStrategy(IConvertCaseStrategy convertCaseStrategy)
        {
            _convertCaseStrategy = convertCaseStrategy;
        }

        public virtual Section GetSection(string sectionName, string filePath = null)
        {
            if (filePath == null)
                return ConfigurationManager.GetSection(sectionName) as Section;

            var fileMap = new ConfigurationFileMap(filePath);
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            return configuration.GetSection(sectionName) as Section;
        }


        public virtual string ConvertCase(string name)
        {
            return _convertCaseStrategy.ConvertCase(name);
        }
    }
}
