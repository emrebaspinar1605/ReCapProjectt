using Business.Abstract;
using Business.Constant;
using Core.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carIDal;
        IFileHelper _file;

        public CarImageManager(ICarImageDal carIDal, IFileHelper file)
        {
            _carIDal = carIDal;
            _file = file;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfMaxImageLimitOfCar(carImage.CarId));
            if (result != null) return result;

            carImage.ImagePath = _file.Upload(formFile, PathConstants.ImagesPath);
            _carIDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _file.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carIDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carIDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarID(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null) return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);

            return new SuccessDataResult<List<CarImage>>(_carIDal.GetAll(ci => ci.CarId == carId));
        }


        public IDataResult<List<CarImageDetailDto>> GetCarImagesDetail()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carIDal.CarImageDetails());
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfMaxImageLimitOfCar(carImage.CarId), DeleteOldImage(carImage.Id, carImage.ImagePath));
            if (result != null) return result;

            

            carImage.ImagePath = _file.Update(formFile, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carIDal.Update(carImage);
            return new SuccessResult();
        }
        public IDataResult<CarImage> GetByImageID(int id)
        {
            return new SuccessDataResult<CarImage>(_carIDal.Get(ci => ci.Id == id));
        }



        #region BusinessRules

        private IResult CheckIfMaxImageLimitOfCar(int carId)
        {
            var result = _carIDal.GetAll(ci => ci.CarId == carId).Count;
            if (result >= 5) return new ErrorResult(Messages.CarImagesOverLimit);

            return new SuccessResult();
        }
        private IResult CheckCarImage(int carId)
        {
            var result = _carIDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0) return new SuccessResult();
            return new ErrorResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            var carImage = new List<CarImage> { new CarImage { CarId = carId, ImagePath = "DefaultImage.jpg" } };
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        #endregion

        private IResult DeleteOldImage(int carImageId, string path)
        {
            var result = _carIDal.Get(ci => ci.Id == carImageId).ImagePath;
            if (File.Exists(path + PathConstants.ImagesPath + result))
            {
                File.Delete(path + PathConstants.ImagesPath + result);
            }
            return new SuccessResult();
        }


    }
}
