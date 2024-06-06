using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetByID(int id);
        IDataResult<Customer> GetByUserID(int userId);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();

    }
}
