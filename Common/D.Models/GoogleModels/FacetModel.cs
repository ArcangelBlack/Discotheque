using System.Runtime.Serialization;

namespace D.Models.GoogleModels
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
