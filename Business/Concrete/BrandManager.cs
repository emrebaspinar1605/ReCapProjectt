using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.BrandAdded);
            }
            catch
            {

                return new ErrorResult(Messages.BrandInvalid);
            }
        }

        public IResult Delete(Brand brand)
        {
            try
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.BrandInvalid);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetByID(int id)
        {
            var temp = _brandDal.Get(b => b.BrandId == id);
            if (temp == null)
            {
                return new ErrorDataResult<Brand>(temp, Messages.BrandInvalid);
            }
            return new SuccessDataResult<Brand>(temp, Messages.GetBrand);
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.BrandInvalid);
            }
        }
    }
}
