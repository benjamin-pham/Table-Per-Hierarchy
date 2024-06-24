using Microsoft.EntityFrameworkCore;
using TPH.Entities;

namespace TPH.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IQueryable<User> Query => applicationDbContext.Set<User>().AsNoTracking();
    }
}
