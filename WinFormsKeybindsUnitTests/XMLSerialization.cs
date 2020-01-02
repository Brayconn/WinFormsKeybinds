using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WinFormsKeybindsUnitTests
{
    static class XMLSerialization
    {
        /// <summary>
        /// Serializes an object to xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Serialize<T>(T input)
        {
            var xs = new XmlSerializer(typeof(T));
            var xml = "";

            using (var sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw))
                {
                    xs.Serialize(xw, input);
                    xml = sw.ToString();
                }
            }

            return xml;
        }

        /// <summary>
        /// Deserializes an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
        {
            T output;
            var s = new XmlSerializer(typeof(T));

            using (var sw = new StringReader(xml))
            {
                using (XmlReader xr = XmlReader.Create(sw))
                {
                    output = (T)s.Deserialize(xr);
                }
            }

            return output;
        }
    }
}
