using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum IncomeEnum : short
{
    [Display(Description = "No Income", Order = 1)] NoIncome = 0,
    [Display(Description = "Welfare/SSI Benefits", Order = 2)] WelfareSSIBenefits = 1,
    [Display(Description = "$18,000 or Less", Order = 3)] Group1 = 2,
    [Display(Description = "$18,001 - $25,000", Order = 4)] Group2 = 3,
    [Display(Description = "$25,001 - $30,000", Order = 5)] Group3 = 4,
    [Display(Description = "$30,001 - $40,000", Order = 6)] Group4 = 5,
    [Display(Description = "$40,001 - $50.000", Order = 7)] Group5 = 6,
    [Display(Description = "$50,001 - $60.000", Order = 8)] Group6 = 7,
    [Display(Description = "$60,001 – And Up", Order = 9)] Group7 = 8,
}
