using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using D.Models.GoogleModels;

namespace DiscothequeW.Utils
{
    public enum SafeLevel { off, medium, high }

    public class SearchEventArgs : EventArgs
    {
        public GoogleSearchResponseModel Response { get; set; }
    }

    public class GoogleSearch
    {
        public GoogleSearch()
        {
            this.Num = 10;
            this.Start = 1;
            this.SafeLevel = SafeLevel.off;
        }
        //
        // PROPERTIES
        //
        public string Key { get; set; }
        public string CX { get; set; }
        public int Num { get; set; }
        public int Start { get; set; }
        public SafeLevel SafeLevel { get; set; }
        //
        // EVENTS
        //
        public event EventHandler<SearchEventArgs> SearchCompleted;
        //
        // METHODs
        //
        protected void OnSearchCompleted(SearchEventArgs e)
        {
            if (this.SearchCompleted != null)
            {
                this.SearchCompleted(this, e);
            }
        }
        public void Search(string search)
        {
            // Check Parameters
            if (string.IsNullOrWhiteSpace(this.Key))
            {
                throw new Exception("Google Search 'Key' cannot be null");
            }
            if (string.IsNullOrWhiteSpace(this.CX))
            {
                throw new Exception("Google Search 'CX' cannot be null");
            }
            if (string.IsNullOrWhiteSpace(search))
            {
                throw new ArgumentNullException("search");
            }
            if (this.Num < 0 || this.Num > 10)
            {
                throw new ArgumentNullException("Num must be between 1 and 10");
            }
            if (this.Start < 1 || this.Start > 100)
            {
                throw new ArgumentNullException("Start must be between 1 and 100");
            }

            // Build Query
            string query = string.Empty;
            query += string.Format("q={0}", search);
            query += string.Format("&key={0}", this.Key);
            query += string.Format("&cx={0}", this.CX);
            query += string.Format("&safe={0}", this.SafeLevel.ToString());
            query += string.Format("&alt={0}", "json");
            query += string.Format("&num={0}", this.Num);
            query += string.Format("&start={0}", this.Start);

            // Construct URL
            UriBuilder builder = new UriBuilder()
            {
                Scheme = Uri.UriSchemeHttps,
                Host = "www.googleapis.com",
                Path = "customsearch/v1",
                Query = query
            };

            // Submit Request
            WebClient w = new WebClient();
            w.DownloadStringCompleted += (a, b) => {
                // Check for errors
                if (b == null) { return; }
                if (b.Error != null) { return; }
                if (string.IsNullOrWhiteSpace(b.Result)) { return; }

                // Desearealize from JSON to .NET objects
                Byte[] bytes = Encoding.Unicode.GetBytes(b.Result);
                MemoryStream memoryStream = new MemoryStream(bytes);
                DataContractJsonSerializer dataContractJsonSerializer =
                    new DataContractJsonSerializer(typeof(GoogleSearchResponseModel));
                var googleSearchResponse =
               dataContractJsonSerializer.ReadObject(memoryStream) as GoogleSearchResponseModel;
                memoryStream.Close();

                // Raise Event
                this.OnSearchCompleted(
                    new SearchEventArgs()
                    {
                        Response = googleSearchResponse
                    }
                );
            };
            w.DownloadStringAsync(builder.Uri);

        }
    }
}
