using Defender.BudgetTracker.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.Reviews;

public class CalculatedTotals
{
    [BsonRepresentation(BsonType.String)]
    public Currency Currency { get; set; }

    public long Amount { get; set; }
}
