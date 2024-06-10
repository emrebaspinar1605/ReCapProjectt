using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidation))]
        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidation(), brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetByID(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.GetBrand);
        }
        [ValidationAspect(typeof(BrandValidation))]
        public IResult Update(Brand brand)
        {
            ValidationTool.Validate(new BrandValidation(), brand);

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);

        }
    }
}
