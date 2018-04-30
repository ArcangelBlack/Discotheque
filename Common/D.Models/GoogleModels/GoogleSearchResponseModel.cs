using System.Collections.Generic;
using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    //setesca
    [DataContract]
    public class GoogleSearchResponseModel
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        [DataMember(Name = "url")]
        public UrlModel Url { get; set; }

        [DataMember(Name = "queries")]
        public QueriesModel Queries { get; set; }

        [DataMember(Name = "context")]
        public ContextModel Context { get; set; }

        [DataMember(Name = "items")]
        public List<ItemModel> Items { get; set; }
    }
}
