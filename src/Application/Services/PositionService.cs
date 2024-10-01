using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.Groups;
using Defender.BudgetTracker.Application.Models.Positions;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;
using Defender.Common.Interfaces;

namespace Defender.BudgetTracker.Application.Services;

public class PositionService(
    IPositionRepository positionRepository,
    ICurrentAccountAccessor currentAccountAccessor) : IPositionService
{
    public Task<PagedResult<Position>> GetCurrentUserPositionsAsync(PaginationRequest paginationRequest)
    {
        var currentUserId = currentAccountAccessor.GetAccountId();

        return positionRepository.GetPositionsAsync(paginationRequest, currentUserId);
    }

    public Task<Position> CreatePositionAsync(CreatePositionRequest createRequest)
    {
        var position = createRequest.CreatePosition();

        position.UserId = currentAccountAccessor.GetAccountId();

        return positionRepository.CreatePositionAsync(position);
    }

    public Task<Position> UpdatePositionAsync(UpdatePositionRequest request)
    {
        var updateRequest = UpdateModelRequest<Position>
            .Init(request.Id)
            .SetIfNotNull(x => x.Currency, request.Currency)
            .SetIfNotNull(x => x.Name, request.Name)
            .SetIfNotNull(x => x.OrderPriority, request.OrderPriority)
            .SetIfNotNull(x => x.Tags, request.Tags);

        return positionRepository.UpdatePositionAsync(updateRequest);
    }

    public async Task<Guid> DeletePositionAsync(Guid positionId)
    {
        await positionRepository.DeletePositionAsync(positionId);

        return positionId;
    }
}
