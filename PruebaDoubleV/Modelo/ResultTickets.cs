using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Modelo
{
    [DataContract]
    public class ResultTickets 
    {
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int totalpages { get; set; }
        [DataMember]
        public int totalItems { get; set; }
        [DataMember]
        public int items { get; set; }
        [DataMember]
        public List<Ticket> Lista { get; set; }
        [DataMember]
        public string error { get; set; }
    }
}