using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);

            _cDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _cDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cDal.GetAll());
        }

        public IDataResult<Customer> GetByID(int id)
        {
            return new SuccessDataResult<Customer>(_cDal.Get(c => c.Id == id), Messages.GetCustomer);
        }
        public IDataResult<List<Customer>> GetByUserID(int userId)
        {
            return new SuccessDataResult<List<Customer>>(_cDal.GetAll(c => c.UserId == userId), Messages.GetCustomer);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_cDal.CustomerDetails());
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);

            _cDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
