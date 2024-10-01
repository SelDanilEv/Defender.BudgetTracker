using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

public interface IPositionRepository
{
    Task<PagedResult<Position>> GetPositionsAsync(
        PaginationRequest pagination, Guid userId);

    Task<Position> CreatePositionAsync(Position newPosition);

    Task<Position> UpdatePositionAsync(UpdateModelRequest<Position> request);

    Task DeletePositionAsync(Guid positionId);
}
