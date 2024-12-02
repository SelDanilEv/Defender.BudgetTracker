using Defender.BudgetTracker.Domain.Enums;
using Defender.Common.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.Rates;

public class HistoricalExchangeRates : IBaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Currency Base { get; set; }

    public DateOnly Date { get; set; }

    public Dictionary<string, decimal> Rates { get; set; } = new();
}