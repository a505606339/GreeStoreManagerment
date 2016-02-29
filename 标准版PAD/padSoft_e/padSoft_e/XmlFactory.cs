using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;

namespace padSoft_e
{
    class XmlFactory
    {
        public void CreateXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmldec;
            xmldec = xmlDocument
                .CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.AppendChild(xmldec);
            XmlElement xmlElement = xmlDocument.CreateElement("", "Barcode", "");
            xmlDocument.AppendChild(xmlElement);
        }

        public void InsertXml(string barcode,string type,string index,string sing)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(sysFunction.exePath() + "\\config\\barcode.xml");
            XmlNode root = xmldoc.SelectSingleNode("Barcode");
            XmlElement xmlEle = xmldoc.CreateElement("Node");
            xmlEle.SetAttribute("code", barcode);
            xmlEle.SetAttribute("sing", sing);
            XmlElement xe2 = xmldoc.CreateElement("type");
            xe2.InnerText = type;
            xmlEle.AppendChild(xe2);
            //XmlElement xe3 = xmldoc.CreateElement("sing");
            //xe3.InnerText = sing;
            //xmlEle.AppendChild(xe3);
            XmlElement xe4 = xmldoc.CreateElement("index");
            xe4.InnerText = index;
            xmlEle.AppendChild(xe4);
            root.AppendChild(xmlEle);
            xmldoc.Save(sysFunction.exePath() + "\\config\\barcode.xml");
        }
        /// <summary>
        /// 返回与条码匹配的XML信息
        /// </summary>
        /// <param name="barcode">要查找的条码</param>
        /// <returns>条码的信息,str[0]为类型,str[1]为位置,str[2]为内机或外机</returns>
        public string[] ReadXml(string barcode)
        {
            string[] str = new string[3];
            string index = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(sysFunction.exePath() + "\\config\\barcode.xml");
            XmlElement root = xmldoc.DocumentElement;
            XmlNode node = xmldoc.SelectSingleNode("Barcode");
            XmlNodeList nodelist = node.ChildNodes;
            foreach (XmlNode x in nodelist)
            {
                XmlElement Xmlele = (XmlElement)x;
                XmlNodeList xl = Xmlele.ChildNodes;
                if (Xmlele.GetAttribute("code") == barcode)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        str[i] = xl.Item(i).InnerText;
                    }
                    str[3] = Xmlele.GetAttribute("sing");
                }
            }
            return str;
        }

        public void DeleteXmlNode(string barcode)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(sysFunction.exePath() + "\\config\\barcode.xml");
            XmlNodeList nodelist = xmldoc.SelectSingleNode("Barcode").ChildNodes;
            XmlNode root = xmldoc.SelectSingleNode("Barcode");
            foreach (XmlNode x in nodelist)
            {
                XmlElement Xmlele = (XmlElement)x;
                if (Xmlele.GetAttribute("code") == barcode)
                {
                    root.RemoveChild(x);
                }
            }
            xmldoc.Save(sysFunction.exePath() + "\\config\\barcode.xml");
        }

        public void ClearXml()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(sysFunction.exePath() + "\\config\\barcode.xml");
            XmlNode root = xmldoc.SelectSingleNode("Barcode");
            root.RemoveAll();
            xmldoc.Save(sysFunction.exePath() + "\\config\\barcode.xml");
        }
    }
}
