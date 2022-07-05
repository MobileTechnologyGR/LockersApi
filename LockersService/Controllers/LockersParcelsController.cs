using LockersService.Model;
using LockersService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LockersService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LockersParcelsController : ControllerBase
    {
        private readonly ILogger<LockersParcelsController> _logger;
        private LockersParcelRepository _lockersParcelRepository; 

        public LockersParcelsController(ILogger<LockersParcelsController> logger)
        {
            _logger = logger;
            _lockersParcelRepository = new LockersParcelRepository();
        }

        [HttpGet(Name = "GetParcels")]
        public async Task<List<CsLockersParcel>> Get()
        {
            var array = await _lockersParcelRepository.GetParcels();
            return array;
        }
    }
}