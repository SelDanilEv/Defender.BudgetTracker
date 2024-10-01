using Defender.BudgetTracker.Domain.Entities.Groups;
using Defender.Common.DB.Model;
using Defender.Common.DB.Pagination;

namespace Defender.BudgetTracker.Application.Common.Interfaces.Repositories;

public interface IGroupRepository
{
    Task<PagedResult<Group>> GetGroupsAsync(
        PaginationRequest pagination, Guid userId);
    Task<Group> CreateGroupAsync(Group newGroup);
    Task<Group> UpdateGroupAsync(UpdateModelRequest<Group> request);
    Task DeleteGroupAsync(Guid GroupId);
}
