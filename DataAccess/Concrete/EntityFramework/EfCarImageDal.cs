using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepository<CarImage, ReCapContext>, ICarImageDal
    {
        public List<CarImageDetailDto> CarImageDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from ci in context.CarImages
                             join c in context.Cars
                             on ci.CarId equals c.CarId
                             join br in context.Brands
                             on c.BrandId equals br.BrandId
                             select new CarImageDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = br.BrandName,
                                 ImagePath = ci.ImagePath,
                                 Date = ci.Date
                             };
                return result.ToList();
            }
        }
    }
}
