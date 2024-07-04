using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
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
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,super,car.add")]
        public IResult Add(Car car)
        {
            var result = BusinessRules.Run(CheckClaimIsCorrect());
            if(result != null)
                return new ErrorResult(result.Message);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            if (car == null)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetCarByID(int id)
        {
            if (id <= 0)
            {
                return new ErrorDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.CarInvalid);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.GetCar);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetails(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandID(int brandId)
        {
            var temp = _carDal.GetAll(c => c.BrandId == brandId);
            if (temp == null)
            {
                return new ErrorDataResult<List<Car>>(temp, Messages.CarInvalid);
            }
            return new SuccessDataResult<List<Car>>(temp, Messages.CarListed);

        }

        public IDataResult<List<Car>> GetCarsByColorID(int colorId)
        {
            var temp = _carDal.GetAll(c => c.ColorId == colorId);
            if (temp == null)
            {
                return new ErrorDataResult<List<Car>>(temp, Messages.CarInvalid);
            }
            return new SuccessDataResult<List<Car>>(temp, Messages.CarListed);

        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);


        }

        #region BusinessRulesMethods
        private IResult CheckClaimIsCorrect()
        {
            if (SecuredOperation.trueRole) return new SuccessResult();
            return new ErrorResult(Messages.AuthorizationDenied);
        }
        #endregion
    }
}
