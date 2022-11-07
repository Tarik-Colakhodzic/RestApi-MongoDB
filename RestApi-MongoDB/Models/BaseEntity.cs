using MongoDB.Bson.Serialization.Attributes;

namespace RestApi_MongoDB.Models
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public DateTime? DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}