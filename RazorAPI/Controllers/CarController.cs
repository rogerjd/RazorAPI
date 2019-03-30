using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RazorAPI.Models;
using static RazorAPI.Services.CarService;

namespace RazorAPI.Controllers
{
    [Route("api/Car")]
    [Produces("application/json")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService; 
        }

        // GET: api/Car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.ReadAll();
        }

        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public Car Get(int id)
        {
            return _carService.Read(id);
        }

        // POST: api/Car
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            _carService.Create(car);
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car car)
        {
            _carService.Update(car);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carService.Delete(id);
        }
    }
}
