using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MediaAirNX.Logic
{
    [Serializable]
 
    public class serializableCollections
    {

        [XmlAttribute]
        public string rr;
        [XmlAttribute]
        public string bb;
        [XmlAttribute]
        public string zz;
        public serializableCollections(string nameSong,string patch, string progress)
        {
            rr = nameSong;
            bb = progress;
            zz = patch;

        }
        public serializableCollections() { }

        public static void Save()
        {
           
        }

        public string Artist { get; set; }
        public string NameSong { get; set; }
        public string Patch { get; set; }
        public string Progress { get; set; }
        public string ImageFilePath { get;  set; }
        public string MusicFilePath { get;  set; }
    }

}
