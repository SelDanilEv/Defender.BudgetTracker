using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Domain.Entities.DiagramSetup;
using Defender.Common.Configuration.Options;
using Defender.Common.DB.Model;
using Defender.Common.DB.Repositories;
using Microsoft.Extensions.Options;

namespace Defender.BudgetTracker.Infrastructure.Repositories;

public class DiagramSetupRepository : BaseMongoRepository<DiagramSetup>, IDiagramSetupRepository
{
    public DiagramSetupRepository(
        IOptions<MongoDbOptions> mongoOption) : base(mongoOption.Value)
    {
    }

    public async Task<DiagramSetup> GetDiagramSetupByUserIdAsync(Guid userId)
    {
        var findRequest = FindModelRequest<DiagramSetup>.Init(u => u.UserId, userId);

        return await GetItemAsync(findRequest);
    }

    public async Task<DiagramSetup> SetDiagramSetupAsync(DiagramSetup setup)
    {
        var findRequest = FindModelRequest<DiagramSetup>.Init(u => u.UserId, setup.UserId);

        return await ReplaceItemAsync(setup, findRequest);
    }
}
