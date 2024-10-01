using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Defender.Common.Attributes;
using Defender.Common.Consts;
using Defender.BudgetTracker.Application.Modules.DiagramSetups.Queries;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.BudgetTracker.Application.Modules.DiagramSetups.Commands;

namespace WebApi.Controllers.V1;

public class DiagramSetupController : BaseApiController
{
    public DiagramSetupController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpGet]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(DiagramSetup), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<DiagramSetup> GetDiagramSetup([FromQuery] GetMainDiagramSetupQuery query)
    {
        return await ProcessApiCallAsync<GetMainDiagramSetupQuery, DiagramSetup>(query);
    }

    [HttpPost]
    [Auth(Roles.User)]
    [ProducesResponseType(typeof(DiagramSetup), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<DiagramSetup> Create([FromBody] UpdateMainDiagramSetupCommand command)
    {
        return await ProcessApiCallAsync<UpdateMainDiagramSetupCommand, DiagramSetup>(command);
    }
}
