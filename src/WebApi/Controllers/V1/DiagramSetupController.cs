using System.Threading.Tasks;
using AutoMapper;
using Defender.BudgetTracker.Application.Modules.DiagramSetups.Commands;
using Defender.BudgetTracker.Application.Modules.DiagramSetups.Queries;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.Common.Attributes;
using Defender.Common.Consts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
