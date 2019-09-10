using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{

    class Program
    {

        public static Dictionary<string, string> jsonKeyValues = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            //XmlTextWriter writer = new XmlTextWriter(@"C:\Users\recep.kaya.BIMSADOM\Desktop\denemexml.txt", System.Text.UTF8Encoding.UTF8);
            //writer.Formatting = Formatting.Indented;
            //XmlReaderSettings settings = new XmlReaderSettings();
            //XmlReader reader = XmlReader.Create(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt", settings);
            //XDocument xdoc = XDocument.Load(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");
            //XmlNode root = doc.DocumentElement;
            ////while (reader.Read())
            ////{
            //    //string rootValue = root.Name;
            //    //writer.WriteStartElement("fat:"+rootValue+"");
            //    XmlNodeReader
            //foreach (XElement element in xdoc.Descendants())
            //{
            //    Console.WriteLine(element.Name);
            //}
            //string endNode = xdoc.LastNode.ToString();                
            ////}

            //string json = JsonConvert.SerializeXmlNode(doc);
            //string path = @"C:\Users\recep.kaya.BIMSADOM\Desktop\denemexml.txt";
            //JArray array = JArray.Parse(json);
            //foreach  (JObject obj in array.Children<JObject>())
            //{
            //    foreach (JProperty prop in obj.Properties())
            //    {
            //        string propName = prop.Name;
            //    }
            //}


            //using (var tw = new StreamWriter(path, true))
            //{
            //    tw.WriteLine(json);
            //    tw.Close();
            //}



            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");            
            
            XDocument xdoc = XDocument.Load(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");
           
            XNamespace soapName = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace fatName = "http://fatura.edoksis.net";

            xdoc.Root.Add(new XAttribute(XNamespace.Xmlns + "fat", fatName));
            xdoc.Root.Add(new XAttribute(XNamespace.Xmlns + "soapenv", soapName));

            XmlNodeList nodeList = doc.SelectNodes("//*");
            for (int i = 0 ; i < nodeList.Count; i++)
            {
                nodeList[i].ParentNode.RemoveChild(nodeList[i]);
            }
            xdoc.Save(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");

            foreach (XElement element in xdoc.Descendants())
            {
                element.Name = fatName + element.Name.LocalName;
            }
            xdoc.Save(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");
            var lines = File.ReadAllLines(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt");
            File.WriteAllLines(@"C:\Users\recep.kaya.BIMSADOM\Desktop\xmlformatı.txt", lines.Skip(1).ToArray());
        }
    }

}




