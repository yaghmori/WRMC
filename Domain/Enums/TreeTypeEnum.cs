using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum TreeTypeEnum : short
{
    [Display(Order = 1)]
    Root = 0,
    [Display(Order = 2)] 
    Node = 1,
    [Display(Order = 3)]
    Leaf = 2,


}