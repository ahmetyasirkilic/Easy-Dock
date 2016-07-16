using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace EasyDock
{
    class Apps
    {
        /// <summary>
        /// Get or set application count on dock
        /// </summary>
        public static int APP_COUNT { get; set; }

        private static int counter = 0;

        /// <summary>
        /// Add app in apps.xml with values
        /// </summary>
        /// <param name="stream">Shortcut target path</param>
        /// <param name="icon">Shortcut icon</param>
        /// <param name="name">Shortcut name</param>
        public static void Add(string stream, string name)
        {
            using (XmlTextWriter xmlWriter = new XmlTextWriter(Environment.CurrentDirectory + "apps.xml", Encoding.UTF8))
            {
                XDocument xDocument = XDocument.Load("apps.xml");
                XElement xElement = xDocument.Element("Applications");
                IEnumerable<XElement> rows = xElement.Descendants("App");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                    new XElement("App",
                    new XElement("Name", name),
                    new XElement("Target-Path", stream)));
                xDocument.Save("apps.xml");
            }
        }

        /// <summary>
        /// Read xml file and fill lists
        /// </summary>
        /// <param name="names">Shortcut names</param>
        /// <param name="icons">Shortcut icons</param>
        /// <param name="paths">Shortcut target path</param>
        public static void Read(ref List<string> names, ref List<string> paths)
        {
            using (XmlTextReader reader = new XmlTextReader("apps.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        switch (counter)
                        {
                            case 0:
                                names.Add(reader.Value);
                                break;
                            case 1:
                                paths.Add(reader.Value);
                                counter = -1;
                                break;
                            default:
                                break;
                        }
                        counter++;
                    }
                }
            }
        }

        /// <summary>
        /// Calculate applications count (Max Count: 10)
        /// </summary>
        /// <param name="names">Shortcut names</param>
        /// <param name="icons">Shortcut icons</param>
        /// <param name="paths">Shortcut target path</param>
        public static void CalcAppCount(ref List<string> names, ref List<string> paths)
        {
            if (names.Count > 10)
            {
                names.RemoveAt(10);
                paths.RemoveAt(10);
                APP_COUNT = names.Count;
            }
            else
            {
                APP_COUNT = names.Count;
            }
        }

    }
}
