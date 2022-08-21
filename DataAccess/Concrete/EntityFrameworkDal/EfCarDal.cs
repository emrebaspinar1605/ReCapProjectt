using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entity.DTOs;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFrameworkDal
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {


        public void Display()
        {
            using (RentCarContext context = new RentCarContext())
            {
                List<Car> entities = context.Set<Car>().ToList();
                foreach (var item in entities)
                {
                    Console.WriteLine("Id: {0} -- Brand Id: {1} -- Color Id: {2} -- Model Year: {3} -- Daily Price: {4} -- Description: {5}", item.Id, item.BrandId, item.ColorId, item.ModelYear, item.DailyPrice, item.Description);
                }
            }
            Console.WriteLine("----------------------------------\n");
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join cl in context.Colors on c.ColorId equals cl.Id
                             select new CarDetailsDto
                             {
                                 Id=c.Id,
                                 ModelYear=c.ModelYear,
                                 CarName = c.Description,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

    }
}
