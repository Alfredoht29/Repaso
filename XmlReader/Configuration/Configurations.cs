using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlReader
{
    [XmlRoot("configsection")]
    public class Configurations
    {
        static Configurations classInstance = null;
        static object classLock=new object();

        public static Configurations Instance
        {
            get
            {
                lock (classLock) 
                { 
                    if(classInstance == null)
                    {
                        classInstance = new Configurations();
                        classInstance.getConfig();
                    }
                }
                return classInstance;
            }
        }


        [XmlElement("machine")]
        public string Machine { get; set; }
        [XmlElement("code")]
        public string Code { get; set; }
        [XmlElement("filter")]
        public string filter { get; set; }

        private Configurations() { }
        private Configurations(string machine,string code,string filter)
        {
            Machine = machine;
            Code = code;
            this.filter = filter;
        }
        public void setConfigMachine(Configurations configurations)
        {
            Machine = configurations.Machine;
            Code = configurations.Code;
            filter = configurations.filter;
        }
        public Configurations getConfigMachine()
        {
            Configurations configurations = new Configurations();
            configurations.Machine = Machine;
            configurations.Code = Code;
            configurations.filter = filter;
            return configurations;
        }
        public void getConfig()
        {
            string url = ConfigurationManager.AppSettings["configdir"].ToString().ToUpper();
            string config = ConfigurationManager.AppSettings["machine"].ToString();
            XmlDocument xmldoc= new XmlDocument();
            xmldoc.Load(url);
            XElement element = XElement.Parse(xmldoc.InnerXml);
            XElement machineconfig = element.Elements("configsection").ToList().FirstOrDefault(x => x.Attribute("name").Value.Equals(config));
            StringReader reader = new StringReader(machineconfig.ToString());
            XmlSerializer xml = new XmlSerializer(typeof(Configurations));
            Configurations configurations = (Configurations)xml.Deserialize(reader);

            Configurations.Instance.setConfigMachine(configurations);
        }
    }
}
