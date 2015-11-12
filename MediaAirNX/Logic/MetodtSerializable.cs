using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MediaAirNX.Logic
{
    public class MetodtSerializable
    {
        //Реализует сериализацию отправленной коллекции в файл
        public void SerializableCollections(List<serializableCollections> cats)
        { 
            using (Stream fStream = new FileStream(MediaAirNX.config.Default.PatchMediaXMLFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<serializableCollections>));
                xmlFormat.Serialize(fStream, cats);
                fStream.Close();
            }
        }

        //Реализует десериализацию 
        public List<serializableCollections> DeSerializableCollections()
        {
            List<serializableCollections> cats;
            using (Stream fStream = new FileStream(MediaAirNX.config.Default.PatchMediaXMLFile, FileMode.Open))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<serializableCollections>));
                cats = (List<serializableCollections>)xmlFormat.Deserialize(fStream);
                fStream.Close();
            }
            return cats;
        }
    }
}
