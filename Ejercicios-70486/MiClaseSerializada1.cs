using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;


namespace Ejercicios_70486
{
    [SerializableAttribute]
    //[Serializable()]
    public class MiClaseSerializada1 //: ISerializable
    {
        public int Edad { get; set; }

        public string Nombre { get; set; }

        [NonSerialized()] public double NoConsiderado;
    }
}
