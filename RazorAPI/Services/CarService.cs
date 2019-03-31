using Microsoft.Extensions.Caching.Memory;
using RazorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAPI.Services
{
    public interface ICarService
    {
        List<Car> ReadAll();
        void Create(Car car);
        Car Read(int id);
        void Update(Car car);
        void Delete(int id);
    }

    public class CarService : ICarService
    {
        const string KeyName = "CarList";

        private readonly IMemoryCache _cache;
        public CarService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Create(Car car)
        {
            var cars = ReadAll();
            car.Id = cars.Max(c => c.Id) + 1;
            cars.Add(car);
            _cache.Set(KeyName, cars);
        }

        public void Delete(int id)
        {
            var cars = ReadAll();
            var deletedCar = Read(id);
            cars.Remove(deletedCar);
            _cache.Set(KeyName, cars);
        }

        public Car Read(int id)
        {
            return ReadAll().Single(c => c.Id == id);
        }

        public List<Car> ReadAll()
        {
            if (_cache.Get(KeyName) == null)
            {
                List<Car> cars = new List<Car>
                    {
                        new Car{Id=1, Make="Audi", Model="R8", Year=2018, Doors=2, Colour="Red", Price=79995},
                        new Car{Id=2, Make="Aston Martin", Model="Rapide", Year=2010, Doors=2, Colour="Black", Price=54995},
                        new Car{Id=3, Make="Porsche", Model="911 991", Year=2016, Doors=2, Colour="White", Price=155000},
                        new Car{Id=4, Make="Mercedes-Benz", Model="GLE 635", Year=2017, Doors=5, Colour="Blue", Price=83995},
                        new Car{Id=5, Make="BMW", Model="X6 M", Year=2016, Doors=5, Colour="Silver", Price=62995}
                    };
                _cache.Set(KeyName, cars);
            }
            return _cache.Get<List<Car>>(KeyName);
        }

        public void Update(Car modifiedCar)
        {
            //var cars = ReadAll();
            //var car = cars.Single(c => c.Id == modifiedCar.Id);
            var car = Read(modifiedCar.Id);
            car.Make = modifiedCar.Make;
            car.Model = modifiedCar.Model;
            car.Doors = modifiedCar.Doors;
            car.Colour = modifiedCar.Colour;
            car.Year = modifiedCar.Year;
            car.Price = modifiedCar.Price;
            //_cache.Set(KeyName, cars);
        }
    }

}
