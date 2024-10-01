using Defender.BudgetTracker.Application.Models.Groups;
using Defender.BudgetTracker.Domain.Entities.Groups;
using Defender.Common.DB.Pagination;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Services;

public interface IGroupService
{
    Task<PagedResult<Group>> GetCurrentUserGroupsAsync(
        PaginationRequest paginationRequest);

    Task<Group> CreateGroupAsync(CreateGroupRequest group);

    Task<Group> UpdateGroupAsync(UpdateGroupRequest request);

    Task<Guid> DeleteGroupAsync(Guid groupId);
}
