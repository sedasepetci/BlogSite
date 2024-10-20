using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Concretes;

public class EfUserRepository : EfRepositoryBase<BaseDbContext, User, long>
{
    public EfUserRepository(BaseDbContext context) : base(context)
    {
    }
}
