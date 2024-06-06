using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _cDal;

        public CustomerManager(ICustomerDal cDal)
        {
            _cDal = cDal;
        }

        public IResult Add(Customer customer)
        {
            try
            {
                _cDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            catch
            {
                return new ErrorResult(Messages.CustomerInvalid);
            }
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _cDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            catch
            {
                return new ErrorResult(Messages.CustomerInvalid);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cDal.GetAll());
        }

        public IDataResult<Customer> GetByID(int id)
        {
            var temp = _cDal.Get(c => c.Id == id);
            if (temp == null)
            {
                return new ErrorDataResult<Customer>(temp, Messages.CustomerInvalid);
            }
            return new SuccessDataResult<Customer>(temp,Messages.GetCustomer);

        }
        public IDataResult<Customer> GetByUserID(int userId)
        {
            var temp = _cDal.Get(c => c.UserId == userId);
            if (temp == null)
            {
                return new ErrorDataResult<Customer>(temp, Messages.CustomerInvalid);
            }
            return new SuccessDataResult<Customer>(temp, Messages.GetCustomer);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_cDal.CustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            try
            {
                _cDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            catch
            {
                return new ErrorResult(Messages.CustomerInvalid);
            }
        }
    }
}
