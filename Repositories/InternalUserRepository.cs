using TPH.Entities;

namespace TPH.Repositories
{
    public class InternalUserRepository : BaseRepository<InternalUser>
    {
        public InternalUserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
