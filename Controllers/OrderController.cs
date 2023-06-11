using InspiroOrder.Data;
using InspiroOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace InspiroOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllOrder")]
        public async Task<ActionResult<List<Order>>> GetAllOrder()
        {
            try
            {
                if (_context.Order == null)
                {
                    return BadRequest(NotFound());
                }
                return Ok(await _context.Order.ToListAsync());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
        // sample 6 data insert for paging
        [HttpPost("PostDataSample")]
        public async Task<ActionResult<Order>> PostDataSample()
        {
            try
            {
                var posData = new List<Order>
                {
                    new Order
                    {
                        CustomerID = 1,
                        OrderDate = DateTime.Now,
                        TotalPayment = 20000
                    },
                };

                //remove all
                if (_context.Order.Count() > 0)
                {
                    var foodsData = _context.Order;
                    foreach (var item in foodsData)
                    {
                        _context.Order.Remove(item);
                    }
                    _context.SaveChanges();
                }

                //add sample
                _context.AddRange(posData);
                await _context.SaveChangesAsync();

                return Ok(await _context.Food.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
