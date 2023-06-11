using InspiroOrder.Data;
using InspiroOrder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspiroOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodController(DataContext context)
        {
            _context = context;
        }

        // sample 6 data insert for paging
        [HttpPost("PostDataSample")]
        public async Task<ActionResult<Food>> PostDataSample()
        {
            try
            {
                var posData = new List<Food>
                {
                    new Food
                    {
                        NameFood = "Paket McSpicy Medium",
                        Description = "Paket McSpicy medium with ice cola drink and potato fries",
                        Price = 50000
                    },
                    new Food
                    {
                        NameFood = "Paket Nasi Uduk Mcd",
                        Description = "Paket nasi uduk mcd with hot coffee",
                        Price = 52000
                    },
                    new Food
                    {
                        NameFood = "2x Hershey McFlurry",
                        Description = "Hershey mcflurry with choco balls + Hershey mcflurry with chocho crumbs ",
                        Price = 30000
                    },
                    new Food
                    {
                        NameFood = "Pahebat Chesee Burger Deluxe",
                        Description = "Paket hebat chesee burger deluxe with ice cola and chicken nugget",
                        Price = 70000
                    },
                     new Food
                    {
                        NameFood = "PaNas 2 Spicy Large",
                        Description = "Paket panas 2 spicy chicken with rice and ice tea",
                        Price = 40000
                    },
                      new Food
                    {
                        NameFood = "Paket McSpicy Nuggets 6",
                        Description = "Paket hemat 6 spicy nuggets with sprite and potato fries",
                        Price = 65000
                    },
                };

                //remove all
                if (_context.Food.Count() > 0)
                {
                    var foodsData = _context.Food;
                    foreach (var item in foodsData)
                    {
                        _context.Food.Remove(item);
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

        [HttpGet("GetAllFood")]
        public async Task<ActionResult<List<Food>>> GetAllFood()
        {
            try
            {
                if (_context.Food == null)
                {
                    return BadRequest(NotFound());
                }
                return Ok(await _context.Food.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }       
            
    }
}
