using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPH.Entities;
using TPH.Repositories;

namespace TPH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalUserController : ControllerBase
    {
        private readonly InternalUserRepository internalUserRepository;
        public InternalUserController(InternalUserRepository internalUserRepository)
        {
            this.internalUserRepository = internalUserRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await internalUserRepository.Query.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await internalUserRepository.Query.SingleOrDefaultAsync(customer => customer.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(InternalUser request)
        {
            await internalUserRepository.AddAsync(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(InternalUser request)
        {
            InternalUser? user = await internalUserRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return BadRequest();
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Address = request.Address;
            user.Username = request.Username;
            user.PasswordHash = request.PasswordHash;
            await internalUserRepository.AddAsync(user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            InternalUser? user = await internalUserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            await internalUserRepository.DeleteAsync(user);
            return Ok();
        }
    }
}
