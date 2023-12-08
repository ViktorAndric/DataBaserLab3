using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


namespace DatabaserLab3.Models
{
    public class UserModel
    {
        [BsonId]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
