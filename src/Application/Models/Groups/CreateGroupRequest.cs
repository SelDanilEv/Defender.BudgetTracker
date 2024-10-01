using Defender.BudgetTracker.Domain.Entities.Groups;

namespace Defender.BudgetTracker.Application.Models.Groups;

public record CreateGroupRequest
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public List<string> Tags { get; set; } = [];
    public string MainColor { get; set; } = string.Empty;

    public bool ShowTrendLine { get; set; }
    public string TrendLineColor { get; set; } = string.Empty;

    public Group CreateGroup(Guid userId) => new()
    {
        UserId = userId,
        Name = Name,
        IsActive = IsActive,
        Tags = Tags,
        MainColor = MainColor,
        ShowTrendLine = ShowTrendLine,
        TrendLineColor = TrendLineColor
    };
}
