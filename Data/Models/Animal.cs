using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public partial class Animal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
