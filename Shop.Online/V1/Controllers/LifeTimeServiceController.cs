using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;

namespace Shop.Online.V1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class LifeTimeServiceController : ControllerBase
    {
        private readonly ISingletonService _singlton1;
        private readonly IScopedService _scoped1;
        private readonly ITransientService _transient1;
        private readonly ISingletonService _singlton2;
        private readonly IScopedService _scoped2;
        private readonly ITransientService _transient2;
        public LifeTimeServiceController(ISingletonService singlton1,
                                        ISingletonService singlton2,
                                        IScopedService scoped1,
                                        IScopedService scoped2,
                                        ITransientService transient2,
                                        ITransientService transient1)
        {
            _singlton1 = singlton1;
            _scoped1 = scoped1;
            _transient1 = transient1;
            _singlton2 = singlton2;
            _scoped2 = scoped2;
            _transient2 = transient2;
        }
        [HttpGet("transient")]
        public IActionResult Tarnsient()
        {
            var Id1 = _transient1.getGuid();
            var Id2 = _transient2.getGuid();
            return Ok(new { Id1, Id2 });
        }
        [HttpGet("scoped")]
        public IActionResult Scoped()
        {
            var Id1 = _scoped1.getGuid();
            var Id2 = _scoped2.getGuid();
            return Ok(new { Id1, Id2 });
        }
        [HttpGet("singleton")]
        public IActionResult Singlton()
        {
            var Id1 = _singlton1.getGuid();
            var Id2 = _singlton2.getGuid();
            return Ok(new { Id1, Id2 });
        }
    }
}
