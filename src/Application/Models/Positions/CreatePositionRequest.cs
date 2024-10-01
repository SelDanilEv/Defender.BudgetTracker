using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.BudgetTracker.Domain.Enums;

namespace Defender.BudgetTracker.Application.Models.Positions;

public record CreatePositionRequest
{
    public string Name { get; set; } = string.Empty;

    public Currency Currency { get; set; }

    public List<string> Tags { get; set; } = [];

    public int OrderPriority { get; set; } = -1;

    public Position CreatePosition() => new()
    {
        Name = Name,
        Currency = Currency,
        Tags = Tags,
        OrderPriority = OrderPriority
    };
}
