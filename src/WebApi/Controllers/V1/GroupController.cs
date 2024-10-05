﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Defender.Common.Attributes;
using Defender.Common.Consts;
using Defender.BudgetTracker.Application.Modules.Groups.Queries;
using Defender.Common.DB.Pagination;
using Defender.BudgetTracker.Application.Modules.Groups.Commands;
using System;
using Defender.BudgetTracker.Domain.Entities.Groups;

namespace WebApi.Controllers.V1;

public class GroupController : BaseApiController
{
    public GroupController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(PagedResult<Group>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<PagedResult<Group>> GetGroups([FromQuery] GetGroupsQuery query)
    {
        return await ProcessApiCallAsync<GetGroupsQuery, PagedResult<Group>>(query);
    }

    [HttpPost]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Group> Create([FromBody] CreateGroupCommand command)
    {
        return await ProcessApiCallAsync<CreateGroupCommand, Group>(command);
    }

    [HttpPut]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Group), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Group> Update([FromBody] UpdateGroupCommand command)
    {
        return await ProcessApiCallAsync<UpdateGroupCommand, Group>(command);
    }

    [HttpDelete]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<Guid> Delete(DeleteGroupCommand command)
    {
        return await ProcessApiCallAsync<DeleteGroupCommand, Guid>(command);
    }

}