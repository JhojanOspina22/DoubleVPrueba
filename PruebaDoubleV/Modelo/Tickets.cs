using System;
using System.Runtime.Serialization;

namespace Modelo
{
    [DataContract]
    public class Ticket
    {
        
      
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public string Usuario{ get; set; }
            [DataMember]
            public string FechaCreacion { get; set; }
            [DataMember]
            public string FechaActualizacion { get; set; }
            [DataMember]
            public string Estatus { get; set; }
      
    }
}
