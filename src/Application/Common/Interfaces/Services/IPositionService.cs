using Defender.BudgetTracker.Application.Models.Positions;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.Common.DB.Pagination;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Services;

public interface IPositionService
{
    Task<PagedResult<Position>> GetCurrentUserPositionsAsync(
        PaginationRequest paginationRequest);

    Task<Position> CreatePositionAsync(CreatePositionRequest position);

    Task<Position> UpdatePositionAsync(UpdatePositionRequest request);

    Task<Guid> DeletePositionAsync(Guid positionId);
}
