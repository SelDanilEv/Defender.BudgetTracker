using FluentValidation;
using MediatR;
using Defender.BudgetTracker.Application.Common.Interfaces.Services;

namespace Defender.BudgetTracker.Application.Modules.Groups.Commands;

public record DeleteGroupCommand : IRequest<Guid>
{
    public Guid Id { get; init; }
};

public sealed class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
{
    public DeleteGroupCommandValidator()
    {
    }
}

public sealed class DeleteGroupCommandHandler(IGroupService positionService)
    : IRequestHandler<DeleteGroupCommand, Guid>
{

    public Task<Guid> Handle(
        DeleteGroupCommand request,
        CancellationToken cancellationToken)
    {
        return positionService.DeleteGroupAsync(request.Id);
    }
}
