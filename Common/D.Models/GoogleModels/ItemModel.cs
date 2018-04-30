using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    [DataContract]
    public class ItemModel
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "htmlTitle")]
        public string HtmlTitle { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "displayLink")]
        public string DisplayLink { get; set; }

        [DataMember(Name = "snippet")]
        public string Snippet { get; set; }

        [DataMember(Name = "htmlSnippet")]
        public string HtmlSnippet { get; set; }

        [DataMember(Name = "cacheId")]
        public string CacheId { get; set; }
        //[DataMember(Name = "pagemap")]        *** Cannot deserialize JSON to .NET! ***
        //public Pagemap Pagemap { get; set; }
    }
}
