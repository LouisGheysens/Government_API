using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Models
{
    public partial class Company
    {
        public Company()
        {
            Persons = new HashSet<Person>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string CompanyName { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string HomeNumber { get; set; } = null!;

        public string City { get; set; } = null!;

        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Person> Persons { get; set; }
    }
}
