using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace D.Models.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public HttpContent Data { get; set; }

        public string Url { get; set; }
    }
}
