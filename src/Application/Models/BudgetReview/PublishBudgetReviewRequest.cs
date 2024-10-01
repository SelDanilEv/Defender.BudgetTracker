namespace Defender.BudgetTracker.Application.Models.BudgetReview;

public record PublishBudgetReviewRequest
{
    public Guid? Id { get; set; }

    public DateOnly Date { get; set; }

    public List<PositionToPublish> ReviewedPositions { get; set; } = [];
}
