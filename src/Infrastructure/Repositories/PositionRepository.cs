using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.Common.Configuration.Options;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;
using Defender.Common.DB.Repositories;
using Microsoft.Extensions.Options;

namespace Defender.BudgetTracker.Infrastructure.Repositories;

public class PositionRepository : BaseMongoRepository<Position>, IPositionRepository
{
    public PositionRepository(
        IOptions<MongoDbOptions> mongoOption) : base(mongoOption.Value)
    {
    }

    public Task<PagedResult<Position>> GetPositionsAsync(PaginationRequest pagination, Guid userId)
    {
        var filter = FindModelRequest<Position>
            .Init(p => p.UserId, userId)
            .Sort(p => p.OrderPriority, SortType.Desc);

        var settings = PaginationSettings<Position>
            .FromPaginationRequest(pagination);

        settings.SetupFindOptions(filter);

        return GetItemsAsync(settings);
    }

    public Task<Position> CreatePositionAsync(Position newPosition)
    {
        return AddItemAsync(newPosition);
    }

    public Task<Position> UpdatePositionAsync(UpdateModelRequest<Position> request)
    {
        return UpdateItemAsync(request);
    }

    public Task DeletePositionAsync(Guid positionId)
    {
        return RemoveItemAsync(positionId);
    }
}
