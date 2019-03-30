using Microsoft.Extensions.Caching.Memory;
using RazorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorAPI.Services
{
    public class CarService
    {
        public interface ICarService
        {
            List<Car> ReadAll();
            void Create(Car car);
            Car Read(int id);
            void Update(Car car);
            void Delete(int id);
        }

        public class CarServive : ICarService
        {
            private readonly IMemoryCache _cache;
            public CarServive(IMemoryCache cache)
            {
                _cache = cache;
            }

            public void Create(Car car)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }

            public Car Read(int id)
            {
                throw new NotImplementedException();
            }

            public List<Car> ReadAll()
            {
                if (_cache.Get("CarList") == null)
                {
                    List<Car> cars = new List<Car>
                    {
                        new Car{Id=1, Make="Audi", Model="R8", Year=2018, Doors=2, Colour="Red", Price=79995},
                        new Car{Id=2, Make="Aston Martin", Model="Rapide", Year=2010, Doors=2, Colour="Black", Price=54995},
                        new Car{Id=3, Make="Porsche", Model="911 991", Year=2016, Doors=2, Colour="White", Price=155000},
                        new Car{Id=4, Make="Mercedes-Benz", Model="GLE 635", Year=2017, Doors=5, Colour="Blue", Price=83995},
                        new Car{Id=5, Make="BMW", Model="X6 M", Year=2016, Doors=5, Colour="Silver", Price=62995}
                    };
                    _cache.Set("CarList", cars);
                }
                return _cache.Get<List<Car>>("CarList");
            }

            public void Update(Car car)
            {
                throw new NotImplementedException();
            }
        }
    }
}
