using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Domain.Entities.Groups;
using Defender.Common.Configuration.Options;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;
using Defender.Common.DB.Repositories;
using Microsoft.Extensions.Options;

namespace Defender.BudgetTracker.Infrastructure.Repositories;

public class GroupRepository : BaseMongoRepository<Group>, IGroupRepository
{
    public GroupRepository(
        IOptions<MongoDbOptions> mongoOption) : base(mongoOption.Value)
    {
    }

    public Task<PagedResult<Group>> GetGroupsAsync(PaginationRequest pagination, Guid userId)
    {
        var filter = FindModelRequest<Group>
            .Init(p => p.UserId, userId);

        var settings = PaginationSettings<Group>
            .FromPaginationRequest(pagination);

        settings.SetupFindOptions(filter);

        return GetItemsAsync(settings);
    }

    public Task<Group> CreateGroupAsync(Group newGroup)
    {
        return AddItemAsync(newGroup);
    }

    public Task<Group> UpdateGroupAsync(UpdateModelRequest<Group> request)
    {
        return UpdateItemAsync(request);
    }

    public Task DeleteGroupAsync(Guid groupId)
    {
        return RemoveItemAsync(groupId);
    }
}
