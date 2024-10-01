﻿using Defender.BudgetTracker.Domain.Entities.Interfaces;
using Defender.Common.Entities;

namespace Defender.BudgetTracker.Domain.Entities.Groups;

public class Group : IUserOwnedModel, IBaseModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public List<string> Tags { get; set; } = [];
    public string MainColor { get; set; } = string.Empty;

    public bool ShowTrendLine { get; set; }
    public string TrendLineColor { get; set; } = string.Empty;
}
