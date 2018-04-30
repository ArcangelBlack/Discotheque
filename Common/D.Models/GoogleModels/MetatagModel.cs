using System.Runtime.Serialization;

namespace D.Models.GoogleModels
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
