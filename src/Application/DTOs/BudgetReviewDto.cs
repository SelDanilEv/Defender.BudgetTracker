using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.BudgetTracker.Domain.Entities.Rates;
using Defender.BudgetTracker.Domain.Entities.Reviews;

namespace Defender.BudgetTracker.Application.DTOs;

public class BudgetReviewDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public DateOnly Date { get; set; }

    public List<ReviewedPosition> Positions { get; set; } = [];

    public RatesModel RatesModel { get; set; } = new();

    public List<CalculatedTotals> CalculatedTotals { get; set; } = [];
}

