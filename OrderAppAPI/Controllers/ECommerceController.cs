using Microsoft.AspNetCore.Mvc;
using OrderAppAPI.Models;

namespace OrderAppAPI.Controllers
{
    public class ECommerceController : Controller
    {
        [HttpPost]
        [Route("order")]
        public IActionResult SubmitOrder(Order order)
        {
            Random random = new Random();
            if (ModelState.IsValid)
            {
                order.OrderNo = random.Next(1, 10000); 
                return Json(new {
                    order
                });
            }

            // flatten out nested list. so now we only have a list that contains model.Errors. Then for each of model.errors, we 
            string errors = string.Join("\n", ModelState.Values.SelectMany(model => model.Errors).Select(e => e.ErrorMessage));
            return BadRequest(errors);
        }
    }
}
