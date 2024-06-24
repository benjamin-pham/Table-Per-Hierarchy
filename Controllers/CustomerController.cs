using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPH.Entities;
using TPH.Repositories;

namespace TPH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await customerRepository.Query.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await customerRepository.Query.SingleOrDefaultAsync(customer => customer.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer request)
        {
            await customerRepository.AddAsync(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(Customer request)
        {
            Customer? customer = await customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                return BadRequest();
            }
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Email = request.Email;
            customer.PhoneNumber = request.PhoneNumber;
            customer.Address = request.Address;
            customer.Username = request.Username;
            customer.PasswordHash = request.PasswordHash;
            await customerRepository.UpdateAsync(customer);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Customer? customer = await customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return BadRequest();
            }
            await customerRepository.DeleteAsync(customer);
            return Ok();
        }
    }
}
