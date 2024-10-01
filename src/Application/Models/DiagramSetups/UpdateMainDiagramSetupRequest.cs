using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.BudgetTracker.Domain.Enums;

namespace Defender.BudgetTracker.Application.Models.DiagramSetups;

public record UpdateMainDiagramSetupRequest
{
    public DateOnly EndDate { get; set; }
    public int LastMonths { get; set; }
    public DiagramSetupCurrency MainCurrency { get; set; }

    public DiagramSetup MapToDiagramSetup(Guid userId) =>
        new()
        {
            UserId = userId,
            EndDate = EndDate,
            LastMonths = LastMonths,
            MainCurrency = MainCurrency
        };
}