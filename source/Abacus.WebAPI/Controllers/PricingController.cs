using Abacus.Core.Resolvable;
using Abacus.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Abacus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingService pricingService;

        public PricingController(IPricingService pricingService)
        {
            this.pricingService = pricingService ?? throw new System.ArgumentNullException(nameof(pricingService));
        }

        [HttpGet]
        public IActionResult GetPrice()
        {
            var resolvableTarget = new ResolvableFixedCouponBond();
            pricingService.Price(resolvableTarget);
            return Ok(new FixedCouponBond());
        }
    }

    public class ResolvableFixedCouponBond : IResolvable<FixedCouponBond>
    {
        public FixedCouponBond Resolve(IResolver resolver)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPricingService
    {
        object Price<T>(T target);
    }
}
