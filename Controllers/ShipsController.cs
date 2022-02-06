using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipManagementApi.Models.Ships;
using ShipManagementApi.BL;
using ShipManagementApi.Entities;
using ShipManagementApi.Helpers;

namespace ShipManagementApi.Controllers
{
    [Route("api/ships")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private IBaseService<Ship> _shipService;
        private IMapper _mapper;

        public ShipsController(
            IBaseService<Ship> shipService,
            IMapper mapper)
        {
            _shipService = shipService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ships = await _shipService.GetAll();
            return Ok(ships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ship>> GetById(int id)
        {
            var ship = await _shipService.Get(id);
            return Ok(ship);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipRequest model)
        {
            if(await CheckIfCodeExists(model.Code))
            {
                throw new AppException("Ship with the code '" + model.Code + "' already exists");
            }
            var ship=_mapper.Map<Ship>(model);
            await _shipService.Insert(ship);
            return CreatedAtAction("GetById", new { id = ship.Id }, ship);
        }

        public async Task<bool> CheckIfCodeExists(string code)
        {
            var ships = await _shipService.GetAll();
            return (ships.Any(x => x.Code == code));         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ShipRequest model)
        {
            if(await CheckIfCodeExists(model.Code))
            {
                throw new AppException("Ship with the code '" + model.Code + "' already exists");
            }
            var ship=_mapper.Map<Ship>(model);
            ship.Id=id;
            await _shipService.Update(ship);
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
