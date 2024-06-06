using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            try
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            catch
            {

                return new ErrorResult(Messages.ColorInvalid);
            }
        }

        public IResult Delete(Color color)
        {
            try
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
            catch
            {

                return new ErrorResult(Messages.ColorInvalid);
            }
        }
        public IDataResult<List<Color>> GetAll()
        {

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetByID(int id)
        {
            var temp = _colorDal.Get(c => c.ColorId== id);
            if (temp == null)
            {
                return new ErrorDataResult<Color>(temp, Messages.ColorInvalid);
            }
            return new SuccessDataResult<Color>(temp, Messages.GetColor);
        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
            catch
            {

                return new ErrorResult(Messages.ColorInvalid);
            }
        }
    }
}
