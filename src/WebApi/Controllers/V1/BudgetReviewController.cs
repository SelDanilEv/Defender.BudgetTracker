using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Defender.Common.Attributes;
using Defender.Common.Consts;
using Defender.BudgetTracker.Application.Modules.BudgetReviews.Queries;
using Defender.Common.DB.Pagination;
using Defender.BudgetTracker.Application.Modules.BudgetReviews.Commands;
using System;
using Defender.BudgetTracker.Application.DTOs;


namespace WebApi.Controllers.V1;

public class BudgetReviewController : BaseApiController
{
    public BudgetReviewController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(PagedResult<BudgetReviewDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<PagedResult<BudgetReviewDto>> GetBudgetReviewsAsync([FromQuery] GetBudgetReviewsQuery query)
    {
        return await ProcessApiCallAsync<GetBudgetReviewsQuery, PagedResult<BudgetReviewDto>>(query);
    }

    [HttpGet("template")]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(BudgetReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<BudgetReviewDto> GetTemplateAsync([FromQuery] GetBudgetReviewTemplateQuery query)
    {
        return await ProcessApiCallAsync<GetBudgetReviewTemplateQuery, BudgetReviewDto>(query);
    }

    [HttpPost]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(BudgetReviewDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<BudgetReviewDto> PublishReviewAsync([FromBody] PublishBudgetReviewCommand command)
    {
        return await ProcessApiCallAsync<PublishBudgetReviewCommand, BudgetReviewDto>(command);
    }

    [HttpDelete]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Guid> DeleteAsync(DeleteBudgetReviewCommand command)
    {
        return await ProcessApiCallAsync<DeleteBudgetReviewCommand, Guid>(command);
    }

}
