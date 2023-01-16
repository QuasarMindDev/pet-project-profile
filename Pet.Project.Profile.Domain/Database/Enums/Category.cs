using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Enums;

public enum Category
{
    [BsonRepresentation(BsonType.String)]
    Dogs = 0,

    [BsonRepresentation(BsonType.String)]
    Cats = 1,

    [BsonRepresentation(BsonType.String)]
    Hamsters = 2,

    [BsonRepresentation(BsonType.String)]
    Rabbits = 3,

    [BsonRepresentation(BsonType.String)]
    Birds = 4,

    [BsonRepresentation(BsonType.String)]
    Fish = 5,

    [BsonRepresentation(BsonType.String)]
    Reptiles = 6,

    [BsonRepresentation(BsonType.String)]
    Other = 7
}
