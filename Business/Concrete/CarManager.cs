﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.Description?.Length < 2 || car.DailyPrice <= 0)
            {
                Console.WriteLine("Lütfen Geçerli Araba Bilgileri Giriniz.");
                return;
            }
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetCarByID(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.CarDetails();
        }

        public List<Car> GetCarsByBrandID(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);

        }

        public List<Car> GetCarsByColorID(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);

        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
