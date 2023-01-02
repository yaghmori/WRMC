using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.UnitOfWork.RepositoriesInterfaces;

public interface ISectionRepository : IRepository<Section>
{
    IEnumerable<Section> GetChildFlatten(Guid id);
}