using MongoDB.Bson.Serialization.Attributes;

namespace RestApi_MongoDB.Models
{
    [BsonIgnoreExtraElements]
    public class User : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public bool Status { get; set; } 

        public Address? Address { get; set; }
        public ICollection<Permission>? Permissions { get; set; }
    }
}