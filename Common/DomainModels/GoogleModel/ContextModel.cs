using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DomainModels.GoogleModel
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
