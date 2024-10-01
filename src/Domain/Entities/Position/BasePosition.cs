using Defender.BudgetTracker.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.Position;

public class BasePosition
{
    public string Name { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.String)]
    public Currency Currency { get; set; }

    public List<string> Tags { get; set; } = [];

    public int OrderPriority { get; set; }
}
