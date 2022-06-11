using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public partial class Person
    {
        public Person()
        {
            Animals = new HashSet<Animal>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        public virtual Company Company { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
