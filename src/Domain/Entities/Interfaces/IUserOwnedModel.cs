namespace Defender.BudgetTracker.Domain.Entities.Interfaces;

public interface IUserOwnedModel
{
    Guid UserId { get; set; }
}
