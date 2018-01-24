using Emrys.SuperConfig.Exceptions;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace Emrys.SuperConfig
{

    /// <summary>
    /// 配置文件配合的节点
    /// </summary>
    public class Section : ConfigurationSection
    {
        /// <summary>
        /// 配置文件的xml
        /// </summary>

        public XElement XElement { get; set; }

        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="reader"></param>
        protected override void DeserializeSection(XmlReader reader)
        {
            XElement = XElement.Load(reader);
        }

        public static explicit operator XElement(Section section)
        {
            if (section.XElement == null)
                throw new SuperConfigException($"未在配置文件中找到 section '{section.SectionInformation.Name}'。");

            return section.XElement;
        }
    }
}