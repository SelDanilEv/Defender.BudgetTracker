using Defender.BudgetTracker.Domain.Entities.Interfaces;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.BudgetTracker.Domain.Entities.Rates;
using Defender.Common.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.Reviews;

public class BudgetReview : IUserOwnedModel, IBaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid UserId { get; set; }

    public DateOnly Date { get; set; }

    public List<ReviewedPosition> Positions { get; set; } = [];

    public RatesModel RatesModel { get; set; } = new();

    [BsonIgnore]
    public List<CalculatedTotals> CalculatedTotals =>
        Positions
            .GroupBy(p => p.Currency)
            .Select(g => new CalculatedTotals
            {
                Currency = g.Key,
                Amount = g.Sum(p => p.Amount)
            })
            .ToList();
}
