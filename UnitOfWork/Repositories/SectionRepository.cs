using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Infrastructure.DataAccess.Extensions;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork.RepositoriesInterfaces;

namespace WRMC.Infrastructure.UnitOfWork.Repositories;

public class SectionRepository : Repository<Section>, ISectionRepository
{

    public SectionRepository(DbContext dbContext) : base(dbContext)
    {

    }

    public IEnumerable<Section> GetChildFlatten(Guid id)
    {
        return _dbSet.Where(x => x.Id == id).Include(x => x.Sections).GetChildFlatten(x => x.Sections);

    }






}