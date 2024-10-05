using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.BudgetTracker.Domain.Enums;

namespace Defender.BudgetTracker.Application.Models.DiagramSetups;

public record UpdateMainDiagramSetupRequest
{
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public int LastMonths { get; set; } = 6;
    public DiagramSetupCurrency MainCurrency { get; set; } = DiagramSetupCurrency.ALL;

    public static UpdateMainDiagramSetupRequest DefaultRequest => new UpdateMainDiagramSetupRequest();

    public DiagramSetup MapToDiagramSetup(Guid userId) =>
        new()
        {
            UserId = userId,
            EndDate = EndDate,
            LastMonths = LastMonths,
            MainCurrency = MainCurrency
        };
}