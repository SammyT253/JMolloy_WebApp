using Newtonsoft.Json;

namespace JMolloy.Models.Entities
{
    public class Book
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "AuthorsName")]
        public string AuthorsName { get; set; }

        [JsonProperty(PropertyName = "AmazonLink")]
        public string AmazonLink { get; set; }

        [JsonProperty(PropertyName = "PublicationYear")]
        public int PublicationYear { get; set; }
    }
}
