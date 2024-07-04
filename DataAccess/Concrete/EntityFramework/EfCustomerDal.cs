using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepository<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> CustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var results = from cu in context.Customers
                              join u in context.Users
                              on cu.UserId equals u.Id
                              select new CustomerDetailDto
                              {
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  CompanyName = cu.CompanyName,
                                  Email = u.Email,
                              };
                return results.ToList();
            }
        }
    }
}
