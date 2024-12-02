using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.Common.DB.Pagination;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.Positions.Queries;

public record GetPositionsQuery : PaginationRequest, IRequest<PagedResult<Position>>
{
};

public sealed class GetPositionsQueryValidator : AbstractValidator<GetPositionsQuery>
{
    public GetPositionsQueryValidator()
    {
    }
}

public sealed class GetPositionsQueryHandler(
        IPositionService positionService)
    : IRequestHandler<GetPositionsQuery, PagedResult<Position>>
{

    public Task<PagedResult<Position>> Handle(
        GetPositionsQuery request,
        CancellationToken cancellationToken)
    {
        return positionService.GetCurrentUserPositionsAsync(request);
    }
}
