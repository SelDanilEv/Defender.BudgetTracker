using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Domain.Entities.Groups;
using Defender.Common.DB.Pagination;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.Groups.Queries;

public record GetGroupsQuery : PaginationRequest, IRequest<PagedResult<Group>>
{
};

public sealed class GetGroupsQueryValidator : AbstractValidator<GetGroupsQuery>
{
    public GetGroupsQueryValidator()
    {
    }
}

public sealed class GetGroupsQueryHandler(
        IGroupService positionService)
    : IRequestHandler<GetGroupsQuery, PagedResult<Group>>
{

    public Task<PagedResult<Group>> Handle(
        GetGroupsQuery request,
        CancellationToken cancellationToken)
    {
        return positionService.GetCurrentUserGroupsAsync(request);
    }
}
