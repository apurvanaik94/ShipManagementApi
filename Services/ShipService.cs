using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ShipManagementApi.Entities;
using ShipManagementApi.Helpers;
using ShipManagementApi.Models.Ships;

namespace ShipManagementApi.Services
{
    public interface IShipService
    {
        IEnumerable<Ship> GetAll();
        Ship GetById(int id);
        void Create(ShipRequest model);
        void Update(int id, ShipRequest model);
        void Delete(int id);
    }

    public class ShipService : IShipService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public ShipService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Ship> GetAll()
        {
            return _context.Ships;
        }

        public Ship GetById(int id)
        {
            return getShip(id);
        }

        public void Create(ShipRequest model)
        {
            // validate
            if (_context.Ships.Any(x => x.Code == model.Code))
                throw new AppException("Ship with the code '" + model.Code + "' already exists");

            // map model to new ship object
            var ship = _mapper.Map<Ship>(model);

            // save user
            _context.Ships.Add(ship);
            _context.SaveChanges();
        }

        public void Update(int id, ShipRequest model)
        {
            var ship = getShip(id);

            // validate
            if (ship.Code != ship.Code && _context.Ships.Any(x => x.Code == model.Code))
                throw new AppException("Ship with the code '" + model.Code + "' already exists");

            // copy model to ship and save
            _mapper.Map(model, ship);
            _context.Ships.Update(ship);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var ship = getShip(id);
            _context.Ships.Remove(ship);
            _context.SaveChanges();
        }

        // // helper method
        private Ship getShip(int id)
        {
            var ship = _context.Ships.Find(id);
            if (ship == null) throw new KeyNotFoundException("Ship not found");
            return ship;
        }
    }
}