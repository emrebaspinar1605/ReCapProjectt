using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        public List<CustomerDetailDto> CustomerDetails();
    }
 }
