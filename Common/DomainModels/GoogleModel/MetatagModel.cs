using System.Runtime.Serialization;

namespace DomainModels.GoogleModel
{
    [DataContract]
    public class MetatagModel
    {
        [DataMember(Name = "creationdate")]
        public string Creationdate { get; set; }

        [DataMember(Name = "moddate")]
        public string Moddate { get; set; }
    }
}
