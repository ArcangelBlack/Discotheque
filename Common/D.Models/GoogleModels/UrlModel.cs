using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    [DataContract]
    public class UrlModel
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "template")]
        public string Template { get; set; }
    }
}
