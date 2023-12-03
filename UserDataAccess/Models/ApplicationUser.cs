using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace UserDataAccess.Models
{
    [CollectionName("users")]
    public class ApplicationUser : MongoIdentityUser<Guid>
    {
        [BsonElement("FirstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("LastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("Father")]
        public string? Father { get; set; }

        [BsonElement("BrandId")]
        public string? BrandId { get; set; }
    }
}
