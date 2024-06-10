using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rDal;

        public RentalManager(IRentalDal rDal)
        {
            _rDal = rDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            rental.RentDate = DateTime.UtcNow;
            _rDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rDal.GetAll(), Messages.GetRental);
        }

        public IDataResult<List<Rental>> GetRentalByCarID(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rDal.GetAll(r => r.CarId == carId), Messages.GetRental);
        }

        public IDataResult<List<Rental>> GetRentalByCustomerID(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rDal.GetAll(r => r.CustomerId == customerId), Messages.GetRental);
        }

        public IDataResult<Rental> GetRentalByID(int id)
        {
            return new SuccessDataResult<Rental>(_rDal.Get(r => r.Id == id), Messages.GetRental);
        }



        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rDal.RentalDetails(), Messages.RentalListed);
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            _rDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
