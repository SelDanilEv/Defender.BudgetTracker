using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Defender.BudgetTracker.Application.DTOs;
using Defender.BudgetTracker.Application.Modules.BudgetReviews.Commands;
using Defender.BudgetTracker.Application.Modules.BudgetReviews.Queries;
using Defender.Common.Attributes;
using Defender.Common.Consts;
using Defender.Common.DB.Pagination;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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

    [HttpGet("by-date-range")]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(List<BudgetReviewDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<List<BudgetReviewDto>> GetBudgetReviewsByDateRangeAsync(
        [FromQuery] GetBudgetReviewsByDateRangeQuery query)
    {
        return await ProcessApiCallAsync<GetBudgetReviewsByDateRangeQuery, List<BudgetReviewDto>>(query);
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
