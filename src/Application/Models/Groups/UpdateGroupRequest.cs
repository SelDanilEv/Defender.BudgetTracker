namespace Defender.BudgetTracker.Application.Models.Groups;

public record UpdateGroupRequest
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public bool? IsActive { get; set; }

    public List<string>? Tags { get; set; }
    public string? MainColor { get; set; }

    public bool? ShowTrendLine { get; set; }
    public string? TrendLineColor { get; set; }
}