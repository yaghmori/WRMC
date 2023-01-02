using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum TaskStatusEnum : short
{
    Completed = 0,
    InProgress = 1,
    NotCompleted = 2,

}