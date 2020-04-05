using MongoDB.Bson;

namespace App.Domain.Models
{
    public abstract class BaseEntity
    {
        public ObjectId Id { get; set; }
    }
}
