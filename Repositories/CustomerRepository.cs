using Microsoft.EntityFrameworkCore;
using TPH.Entities;

namespace TPH.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
