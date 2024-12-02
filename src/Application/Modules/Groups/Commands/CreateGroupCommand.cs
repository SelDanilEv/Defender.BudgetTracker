using Defender.BudgetTracker.Application.Common.Interfaces.Services;
using Defender.BudgetTracker.Application.Models.Groups;
using Defender.BudgetTracker.Domain.Entities.Groups;
using FluentValidation;
using MediatR;

namespace Defender.BudgetTracker.Application.Modules.Groups.Commands;

public record CreateGroupCommand : CreateGroupRequest, IRequest<Group>
{
};

public sealed class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
    }
}

public sealed class CreateGroupCommandHandler(
        IGroupService positionService)
    : IRequestHandler<CreateGroupCommand, Group>
{

    public Task<Group> Handle(
        CreateGroupCommand request,
        CancellationToken cancellationToken)
    {
        return positionService.CreateGroupAsync(request);
    }
}
