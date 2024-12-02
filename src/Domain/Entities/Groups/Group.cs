using Defender.BudgetTracker.Domain.Entities.Interfaces;
using Defender.Common.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Defender.BudgetTracker.Domain.Entities.Groups;

public class Group : IUserOwnedModel, IBaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    [BsonGuidRepresentation(GuidRepresentation.CSharpLegacy)]
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public List<string> Tags { get; set; } = [];
    public string MainColor { get; set; } = string.Empty;

    public bool ShowTrendLine { get; set; }
    public string TrendLineColor { get; set; } = string.Empty;
}
