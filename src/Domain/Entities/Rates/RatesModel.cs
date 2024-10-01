using Defender.BudgetTracker.Domain.Enums;
using Defender.BudgetTracker.Domain.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.Rates;

public class RatesModel
{
    public DateOnly Date { get; set; }

    [BsonRepresentation(BsonType.String)]
    public Currency BaseCurrency { get; set; }

    [BsonSerializer(typeof(CurrencyDictionarySerializer))]
    public Dictionary<Currency, decimal> Rates { get; set; } = [];
}
