using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    [DataContract]
    public class PageModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "totalResults")]
        public int Request { get; set; }

        [DataMember(Name = "searchTerms")]
        public string SearchTerms { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "startIndex")]
        public int StartIndex { get; set; }

        [DataMember(Name = "inputEncoding")]
        public string InputEncoding { get; set; }

        [DataMember(Name = "outputEncoding")]
        public string OutputEncoding { get; set; }

        [DataMember(Name = "safe")]
        public string Safe { get; set; }

        [DataMember(Name = "cx")]
        public string CX { get; set; }
    }
}
