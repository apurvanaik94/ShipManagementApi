using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShipManagementApi.Models.Ships;
using ShipManagementApi.DAL;
using ShipManagementApi.Entities;
using ShipManagementApi.Helpers;

namespace ShipManagementApi.Controllers
{
    [Route("api/ships")]
    [ApiController]
    public class ShipsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public ShipsController(DataContext context, IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ship>>> GetAll()
        {
            var model =  await _repository.SelectAll<Ship>();
            return model;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ship>> GetById(long id)
        {
            var model = await _repository.SelectById<Ship>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShipRequest model)
        {
            Ship ship=_mapper.Map<Ship>(model);
            await _repository.CreateAsync<Ship>(ship);
            return CreatedAtAction("GetById", new { id = ship.Id }, ship); 
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ShipRequest model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            Ship ship=_mapper.Map<Ship>(model);
            await _repository.UpdateAsync<Ship>(ship);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ship>> Delete(long id)
        {
            var model = await _repository.SelectById<Ship>(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Ship>(model);

            return model;
        }
    }
}
