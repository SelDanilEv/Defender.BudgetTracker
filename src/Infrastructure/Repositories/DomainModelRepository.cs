using Defender.Common.Configuration.Options;
using Defender.Common.DB.Repositories;
using Defender.BudgetTracker.Application.Common.Interfaces.Repositories;
using Defender.BudgetTracker.Domain.Entities;
using Microsoft.Extensions.Options;

namespace Defender.BudgetTracker.Infrastructure.Repositories.DomainModels;

public class DomainModelRepository : BaseMongoRepository<DomainModel>, IDomainModelRepository
{
    public DomainModelRepository(IOptions<MongoDbOptions> mongoOption) : base(mongoOption.Value)
    {
    }

    public async Task<DomainModel> GetDomainModelByIdAsync(Guid id)
    {
        return await GetItemAsync(id);
    }
}
