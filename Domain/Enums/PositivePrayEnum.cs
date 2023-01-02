using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum PositivePrayEnum : short
{
    [Display(Description = "Over the situation", Order = 1)] OverTheSituation = 0,
    [Display(Description = "To receive Christ today", Order = 2)] ToReceiveChristToday = 1,
    [Display(Description = "Re-dedicate Life to Christ ", Order = 3)] ReDedicateLifeToChrist = 2,
}
