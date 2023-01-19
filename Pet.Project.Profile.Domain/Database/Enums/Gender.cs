using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pet.Project.Profile.Domain.Database.Enums;

public enum Gender
{
    [BsonRepresentation(BsonType.String)]
    Male = 0,

    [BsonRepresentation(BsonType.String)]
    Female = 1,

    [BsonRepresentation(BsonType.String)]
    NonBinary = 2
}