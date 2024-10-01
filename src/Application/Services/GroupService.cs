using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.Groups;
using Defender.BudgetTracker.Domain.Entities.Groups;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;
using Defender.Common.Interfaces;

namespace Defender.BudgetTracker.Application.Services;

public class GroupService(
    IGroupRepository groupRepository,
    ICurrentAccountAccessor currentAccountAccessor) : IGroupService
{
    public Task<PagedResult<Group>> GetCurrentUserGroupsAsync(
        PaginationRequest paginationRequest)
    {
        var currentUserId = currentAccountAccessor.GetAccountId();

        return groupRepository.GetGroupsAsync(paginationRequest, currentUserId);
    }

    public Task<Group> CreateGroupAsync(CreateGroupRequest createRequest)
    {
        var group = createRequest.CreateGroup(currentAccountAccessor.GetAccountId());

        return groupRepository.CreateGroupAsync(group);
    }

    public Task<Group> UpdateGroupAsync(UpdateGroupRequest request)
    {
        var updateRequest = UpdateModelRequest<Group>
            .Init(request.Id)
            .SetIfNotNull(x => x.Name, request.Name)
            .SetIfNotNull(x => x.IsActive, request.IsActive)
            .SetIfNotNull(x => x.MainColor, request.MainColor)
            .SetIfNotNull(x => x.ShowTrendLine, request.ShowTrendLine)
            .SetIfNotNull(x => x.TrendLineColor, request.TrendLineColor)
            .SetIfNotNull(x => x.Tags, request.Tags);

        return groupRepository.UpdateGroupAsync(updateRequest);
    }

    public async Task<Guid> DeleteGroupAsync(Guid groupId)
    {
        await groupRepository.DeleteGroupAsync(groupId);

        return groupId;
    }
}
