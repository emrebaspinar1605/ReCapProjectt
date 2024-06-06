using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rDal;

        public RentalManager(IRentalDal rDal)
        {
            _rDal = rDal;
        }

        public IResult Add(Rental rental)
        {
            try
            {
                _rDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            catch 
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
        }

        public IResult Delete(Rental rental)
        {
            try
            {
                _rDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            catch
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var temp = _rDal.GetAll();
            if (temp == null)
            {
                return new ErrorDataResult<List<Rental>>(temp, Messages.RentalNotFound);
            }
            return new SuccessDataResult<List<Rental>>(temp, Messages.GetRental);
        }

        public IDataResult<List<Rental>> GetRentalByCarID(int carId)
        {
            var temp = _rDal.GetAll(r => r.CarId == carId);
            if (temp == null)
            {
                return new ErrorDataResult<List<Rental>>(temp, Messages.RentalNotFound);
            }
            return new SuccessDataResult<List<Rental>>(temp, Messages.GetRental);
        }

        public IDataResult<List<Rental>> GetRentalByCustomerID(int customerId)
        {
            var temp = _rDal.GetAll(r => r.CustomerId == customerId);
            if (temp == null)
            {
                return new ErrorDataResult<List<Rental>>(temp, Messages.RentalNotFound);
            }
            return new SuccessDataResult<List<Rental>>(temp, Messages.GetRental);
        }

        public IDataResult<Rental> GetRentalByID(int id)
        {
            var temp = _rDal.Get(r=>r.Id == id);
            if (temp == null)
            {
                return new ErrorDataResult<Rental>(temp, Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(temp, Messages.GetRental);
        }



        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            var temp = _rDal.RentalDetails();
            if (temp == null)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(temp, Messages.RentalNotFound);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(temp, Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            try
            {
                _rDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            catch
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
        }
    }
}
