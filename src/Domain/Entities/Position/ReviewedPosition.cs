namespace Defender.BudgetTracker.Domain.Entities.Position;

public class ReviewedPosition : BasePosition
{
    public static ReviewedPosition FromPosition(
        BasePosition basePosition,
        long amount = 0)
    {
        return new ReviewedPosition
        {
            Name = basePosition.Name,
            Currency = basePosition.Currency,
            Tags = basePosition.Tags,
            OrderPriority = basePosition.OrderPriority,
            Amount = amount
        };
    }

    public long Amount { get; set; }
}
