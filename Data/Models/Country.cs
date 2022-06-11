using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public partial class Country
    {
        public Country()
        {
            Companies = new HashSet<Company>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Company> Companies { get; set; }
    }
}
