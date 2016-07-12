using System.Runtime.Serialization;
using System.ServiceModel;

namespace Ejercicios_70486
{
    [DataContract]
    public class MiClaseSerializada2
    {
        [DataMember]
        public int Edad { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [OperationContract]
        public void Aja()
        {
        }
    }
}
