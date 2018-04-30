using System.Collections.Generic;
using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    [DataContract]
    public class QueriesModel
    {
        [DataMember(Name = "nextPage")]
        public List<PageModel> NextPage { get; set; }

        [DataMember(Name = "request")]
        public List<PageModel> Request { get; set; }
    }
}
