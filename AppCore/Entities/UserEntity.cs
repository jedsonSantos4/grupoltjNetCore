using MongoDB.Bson.Serialization.Attributes;

namespace AppCore.Entities
{
    public class UserEntity : BaseEntity
    {
        [BsonElement("nome")]
        public string Nome { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        //public DateTime createIndexes { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("role")]
        public string Role { get; set; }

        public UserEntity()
        {
            Role = "default";
        }
    }
}
