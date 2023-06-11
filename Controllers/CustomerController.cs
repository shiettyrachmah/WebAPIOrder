using InspiroOrder.Data;
using InspiroOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspiroOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        //sample data Customer for order 
        [HttpPost("PostDataSample")]
        public async Task<ActionResult<Customer>> PostDataSample()
        {
            try
            {
                var cutomers = new List<Customer>
                {
                    new Customer
                    {
                        Name = "Renjun",
                        Addess = "Mampang Prapatan Street"
                    },
                };

                //remove all
                if(_context.Customer.Count() > 0)
                {
                    var foodsData = _context.Customer;
                    foreach(var item in foodsData)
                    {
                        _context.Customer.Remove(item);
                    }
                    _context.SaveChanges();
                }

                //add
                _context.AddRange(cutomers);
                await _context.SaveChangesAsync();

                return Ok(await _context.Customer.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }       
            
        }

        [HttpGet("GetAllCustomer")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            try
            {
                if (_context.Customer == null)
                {
                    return BadRequest(NotFound());
                }

                return Ok(await _context.Customer.ToListAsync());
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
