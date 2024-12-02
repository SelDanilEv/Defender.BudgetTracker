using Defender.BudgetTracker.Domain.Entities.Interfaces;
using Defender.BudgetTracker.Domain.Enums;
using Defender.Common.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.DiagramSetup;

public class DiagramSetup : IUserOwnedModel, IBaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid UserId { get; set; }

    public DateOnly EndDate { get; set; }
    public int LastMonths { get; set; }

    [BsonRepresentation(BsonType.String)]
    public DiagramSetupCurrency MainCurrency { get; set; }
}
