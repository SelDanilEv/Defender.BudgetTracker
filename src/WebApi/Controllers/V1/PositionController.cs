using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Defender.Common.Attributes;
using Defender.Common.Consts;
using Defender.BudgetTracker.Application.Modules.Positions.Queries;
using Defender.BudgetTracker.Domain.Entities.Position;
using Defender.Common.DB.Pagination;
using Defender.BudgetTracker.Application.Modules.Positions.Commands;
using System;

namespace WebApi.Controllers.V1;

public class PositionController : BaseApiController
{
    public PositionController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(PagedResult<Position>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<PagedResult<Position>> GetPositions([FromQuery] GetPositionsQuery query)
    {
        return await ProcessApiCallAsync<GetPositionsQuery, PagedResult<Position>>(query);
    }

    [HttpPost]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Position), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Position> Create([FromBody] CreatePositionCommand command)
    {
        return await ProcessApiCallAsync<CreatePositionCommand, Position>(command);
    }

    [HttpPut]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Position), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Position> Update([FromBody] UpdatePositionCommand command)
    {
        return await ProcessApiCallAsync<UpdatePositionCommand, Position>(command);
    }

    [HttpDelete]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Guid> Delete(DeletePositionCommand command)
    {
        return await ProcessApiCallAsync<DeletePositionCommand, Guid>(command);
    }

}
