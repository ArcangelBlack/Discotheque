using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainModels.GoogleModel
{
    [DataContract]
    public class PagemapModel
    {
        [DataMember(Name = "metatags")]
        public List<Dictionary<string, string>> Metatags { get; set; }
    }
}
