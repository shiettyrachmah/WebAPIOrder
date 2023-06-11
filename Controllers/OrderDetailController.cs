using InspiroOrder.Data;
using InspiroOrder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json.Nodes;

namespace InspiroOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderDetailController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllOrderDetail")]
        public async Task<ActionResult<List<OrderDetail>>> GetAllOrderDetail()
        {
            try
            {
                if (_context.OrderDetail == null)
                {
                    return BadRequest(NotFound());
                }
                return Ok(await _context.OrderDetail.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SaveDataOrder")]
        public async Task<ActionResult<List<OrderDetail>>> SaveDataOrder([FromForm] string jsonData)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<Orders>(jsonData);

                if (result != null)
                {
                    //order
                    Order newOrder = new Order()
                    {
                        CustomerID = result.CustomerID,
                        OrderDate = result.OrderDate,
                        TotalPayment = result.TotalPayment
                    };
                    _context.Add(newOrder);
                    await _context.SaveChangesAsync();

                    //details
                    var idOrder = await _context.Order.OrderByDescending(x => x.OrderID).FirstOrDefaultAsync();
                    int idOrders = idOrder == null ? 0 : idOrder.OrderID;

                    for (var i = 0; i < result.OrderDetail.Count; ++i)
                    {
                        result.OrderDetail[i].OrderID = idOrders;
                    }
                    _context.AddRange(result.OrderDetail);
                    await _context.SaveChangesAsync();

                    //payment
                    Payment pay = new Payment()
                    {
                        OrderID = idOrders,
                        PaymentDate = result.PaymentDate,
                    };

                    _context.Add(pay);
                    await _context.SaveChangesAsync();
                }

                return Ok(await _context.OrderDetail.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
