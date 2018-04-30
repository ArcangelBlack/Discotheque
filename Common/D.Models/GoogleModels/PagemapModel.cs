using System.Collections.Generic;
using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    [DataContract]
    public class PagemapModel
    {
        [DataMember(Name = "metatags")]
        public List<Dictionary<string, string>> Metatags { get; set; }
    }
}
