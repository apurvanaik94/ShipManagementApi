using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipManagementApi.Models.Ships;
using ShipManagementApi.Services;

namespace ShipManagementApi.Controllers
{
    [Route("api/ships")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private IShipService _shipService;
        private IMapper _mapper;

        public ShipsController(
            IShipService shipService,
            IMapper mapper)
        {
            _shipService = shipService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ships = _shipService.GetAll();
            return Ok(ships);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ship = _shipService.GetById(id);
            return Ok(ship);
        }

        [HttpPost]
        public IActionResult Create(ShipRequest model)
        {
            _shipService.Create(model);
            return Ok(new { message = "Ship created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ShipRequest model)
        {
            _shipService.Update(id, model);
            return Ok(new { message = "Ship updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _shipService.Delete(id);
            return Ok(new { message = "Ship deleted" });
        }
    }
}
