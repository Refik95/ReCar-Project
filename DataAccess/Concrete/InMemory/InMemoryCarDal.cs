using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{  
    public class InMemoryCarDal 
    {
        //List<Car> _cars;
        //public InMemoryCarDal()
        //{
        //    _cars = new List<Car> {
        //        new Car{Id=1, BrandId=1, ColorId=1, Description="Mercedes Eski Model", DailyPrice=15000.5, ModelYear=1998},
        //        new Car{Id=2, BrandId=1, ColorId=2, Description="Mercedes Yeni Model", DailyPrice=1000000, ModelYear=2020},
        //        new Car{Id=3, BrandId=2, ColorId=3, Description="BMW Eski Model", DailyPrice=10000.5, ModelYear=1995},
        //        new Car{Id=4, BrandId=3, ColorId=4, Description="Fiat Yeni Model", DailyPrice=50000, ModelYear=2018}
        //    };
        //}
        //public void Add(Car car)
        //{
        //    _cars.Add(car);
        //}

        //public void Delete(Car car)
        //{
        //    Car carToDelete = _cars.SingleOrDefault(p=>p.Id == car.Id);
        //    _cars.Remove(carToDelete);
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetAll()
        //{
        //    return _cars;
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Car> GetByBrandId(int brandId)
        //{
        //    return _cars;
        //}

        //public List<Car> GetByColorId(int colorId)
        //{
        //   return _cars;
        //}

        //public void Update(Car car)
        //{
        //    Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
        //    carToUpdate.ColorId = car.ColorId;
        //    carToUpdate.Description = car.Description;
        //    carToUpdate.DailyPrice = car.DailyPrice;
        //    carToUpdate.BrandId = car.BrandId;
        //    carToUpdate.ModelYear = car.ModelYear;
        //}

        ////List<Car> ICarDal.GetById(int id)
        ////{
        ////    return _cars.Where(p => p.Id == id).ToList();
        ////}
    }
}
