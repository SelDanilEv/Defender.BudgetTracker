using Defender.BudgetTracker.Domain.Enums;

namespace Defender.BudgetTracker.Application.Models.Positions;

public record UpdatePositionRequest
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Currency? Currency { get; set; }

    public List<string>? Tags { get; set; }

    public int? OrderPriority { get; set; }
}