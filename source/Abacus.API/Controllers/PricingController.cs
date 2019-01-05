using Abacus.Pricing.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new FixedCouponBond());
        }

        [HttpPost]
        public IActionResult Post()
        {
            return null;
        }
    }
}
