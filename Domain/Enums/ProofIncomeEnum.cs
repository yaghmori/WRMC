using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ProofIncomeEnum : short
{
    [Display(Description = "Copy of the last three pay stubs from every person who works in the household", Order = 1)] LastThreePayStubs = 0,
    [Display(Description = "Unemployment benefits statement and proof of payment history", Order = 2)] UnemploymentBenefitsStatement = 1,
    [Display(Description = "Proof of social security/disability income or retirement/pension benefits", Order = 3)] SocialSecurityDisabilityIncome = 2,
    [Display(Description = "If you have direct deposit for these checks, you must provide a bank statement", Order = 4)] DirectDeposit = 3,
    [Display(Description = "Child support/alimony support documentation", Order = 5)] AlimonySupportDocumentation = 4,
    [Display(Description = "If you are paid in cash, your employer must provide a letter verifying your income with contact information", Order = 6)] EmployerLetter = 5,
    [Display(Description = "If self-employed, bring a Profit and Loss statementand three of your most recent bank statements", Order = 7)] ProfitAndLossStatement = 6,
    [Display(Description = "If living on savings, you must provide three of your most recent bank statements", Order = 8)] LivingOnSavings = 7,
    [Display(Description = "If no income, please provide letter of support from the person who provides food and shelter for you", Order = 9)] NoIncome = 8,
}
