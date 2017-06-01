using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Data;

namespace MOMService.Utilities
{
    public static class Common
    {
        public static string ListToXML<TSource>(this IList<TSource> data)
        {
            string xml = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            XPathNavigator nav = xmlDoc.CreateNavigator();
            using (XmlWriter writer = nav.AppendChild())
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<TSource>));
                ser.Serialize(writer, data);
            }
            string s = "ArrayOf" + typeof(TSource).Name;
            string strXML = nav.InnerXml;
            strXML = strXML.Replace("ArrayOf" + typeof(TSource).Name, "root");
            strXML = strXML.Replace(typeof(TSource).Name, "row");
            xml = strXML.ToString();
            return xml;
        }



    }
}