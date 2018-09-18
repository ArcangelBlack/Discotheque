using System.Runtime.Serialization;

namespace DomainModels.GoogleModel
{
    [DataContract]
    public class FacetModel
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }

        [DataMember(Name = "anchor")]
        public string Anchor { get; set; }
    }
}
