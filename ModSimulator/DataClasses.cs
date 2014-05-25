using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModSimulator
{

    [XmlRoot("DR")]
    public class DR
    {

        private readonly List<DP> myDataPacks = new List<DP>();
        [XmlElement("DP", typeof(DP))]
        public List<DP> dataPacks { get { return myDataPacks; } }
        [XmlAttribute]
        public string TV { get; set; } // "Bean Version

    }
      
    public class DP
    {
        
        [XmlAttribute]
        public string Src { get; set; }
        [XmlAttribute]
        public string v { get; set; } // "Bean Version
        private readonly List<DE> myElementList=new List<DE>();
        [XmlElement("DE", typeof(DE))]
        public List<DE> dataElement {get {return myElementList; }}

    }

    
    public class DE
    {
        public DE() { }
        public DE(string name, string type, string value) { N = name; T = type; V = value; }
        [XmlAttribute]
        public string N { get; set; }
        [XmlAttribute]
        public string T { get; set; }
        [XmlElement]
        public string V { get; set; }
    }

}
