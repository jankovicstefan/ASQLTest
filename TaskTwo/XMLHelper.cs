using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TaskTwo
{
    public class XMLHelper
    {

            /// <summary>
            /// This function filters data with specific extensions,
            /// and recursivly creates XElement object with specific attributes.
            /// </summary>
            /// <param name="dir"></param>
            /// <returns>XElement object to be used in the creation of XDocument</returns>
        public XElement CreateAndSaveXml(DirectoryInfo dir)
        {
            List<String> extensions = new List<string>();
            extensions.Add(".exe");
            extensions.Add(".com");
            extensions.Add(".bat");

            XElement info = null;
            try
            {
                 info = new XElement("dir",
                               new XAttribute("FolderName", dir.Name),
                               new XAttribute("NumberOfExecutableFiles", dir.GetFiles().Length));

                 foreach (var file in dir.GetFiles())
                 {
                     foreach (var ext in extensions)    
                     {
                         if (file.Extension == ext)     
                         {
                             info.Add(new XElement("file",
                                      new XAttribute("FileName", file.Name),
                                      new XAttribute("ExecutableType", file.Extension)));
                         }
                     }
                 }

                foreach (var subDir in dir.GetDirectories())
                    info.Add(CreateAndSaveXml(subDir));     
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                
            }
            return info;
        }

            /// <summary>
            /// Load data from XML file with specific name.
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns> List<String>: {FileName, FolderName, ExeType, FileName, FolderName, ExeType...} </returns>
        public List<String> GetXMLData(String fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            List<String> elements = new List<string>();

            foreach (var el in doc.Elements("dir").Descendants("file"))
            {
                elements.Add(el.Attribute("FileName").Value);
                elements.Add(el.Parent.Attribute("FolderName").Value);    
                elements.Add(el.Attribute("ExecutableType").Value);
              
            }
            return elements;
        }
    }
}

