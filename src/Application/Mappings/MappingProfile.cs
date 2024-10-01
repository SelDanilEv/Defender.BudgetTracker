using Defender.BudgetTracker.Application.DTOs;
using Defender.BudgetTracker.Application.Models.BudgetReview;
using Defender.BudgetTracker.Domain.Entities.Reviews;
using Defender.Common.Mapping;

namespace Defender.BudgetTracker.Application.Mappings;

public class MappingProfile : BaseMappingProfile
{
    public MappingProfile()
    {
        CreateMap<PositionToPublish, Domain.Entities.Position.ReviewedPosition>();

        CreateMap<BudgetReview, BudgetReviewDto>();
    }
}
