using Defender.BudgetTracker.Domain.Entities.Interfaces;
using Defender.Common.Entities;

namespace Defender.BudgetTracker.Domain.Entities.Position;

public class Position : BasePosition, IUserOwnedModel, IBaseModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}
