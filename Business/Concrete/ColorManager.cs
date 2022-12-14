using Business.Abstract;
using Business.BusinessAspects;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal=colorDal; 
        }
        [SecuredOperation("admin,color.add")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
          _colorDal.Add(color);
            return new Result(true,Messages.ColorAdded) ;
        }
        [CacheAspect]
        public IDataResult<Color> ColorGetById(int colorId)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id==colorId));
            
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>> (_colorDal.GetAll());
        }
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, Messages.ColorUpdated);
        }
    }
}
