using System.Collections.Generic;
using System.Runtime.Serialization;

namespace D.Models.GoogleModels
{
    [DataContract]
    public class ContextModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "facets")]
        public List<List<FacetModel>> Facets { get; set; }
    }
}
