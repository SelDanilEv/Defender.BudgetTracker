using Defender.BudgetTracker.Domain.Entities.Interfaces;
using Defender.BudgetTracker.Domain.Enums;
using Defender.Common.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Defender.BudgetTracker.Domain.Entities.DiagramSetup;

public class DiagramSetup : IUserOwnedModel, IBaseModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public DateOnly EndDate { get; set; }
    public int LastMonths { get; set; }

    [BsonRepresentation(BsonType.String)]
    public DiagramSetupCurrency MainCurrency { get; set; }
}
