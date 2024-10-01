using FluentValidation;
using MediatR;
using Defender.BudgetTracker.Application.Models.Groups;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Domain.Entities.Groups;

namespace Defender.BudgetTracker.Application.Modules.Groups.Commands;

public record UpdateGroupCommand : UpdateGroupRequest, IRequest<Group>
{
};

public sealed class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupCommandValidator()
    {
    }
}

public sealed class UpdateGroupCommandHandler(
        IGroupService positionService)
    : IRequestHandler<UpdateGroupCommand, Group>
{

    public Task<Group> Handle(
        UpdateGroupCommand request,
        CancellationToken cancellationToken)
    {
        return positionService.UpdateGroupAsync(request);
    }
}
