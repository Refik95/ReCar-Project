using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager :ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult Add(IFormFile file,CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNameExists(carImages.ImagePath),
                CheckIfCarImageCountOfCarIdCorrect(carImages.CarId));

            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = "test";
            carImages.ImageDate = DateTime.Now;
            _carImagesDal.Add(carImages);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(CarImages carImages)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImagesDal.Get(I => I.ImageId== carImages.ImageId).ImagePath;

            var result = BusinessRules.Run(FileHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImagesDal.Delete(carImages);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImages>> GetAll(Expression<Func<CarImages, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(filter));
        }

        public IDataResult<CarImages> GetById(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(ci => ci.ImageId == imageId));
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImagesDal.Get(p => p.ImageId == carImages.ImageId).ImagePath;
            carImages.ImagePath = FileHelper.UpdateAsync(oldpath, file);
            carImages.ImageDate = DateTime.Now;
            _carImagesDal.Update(carImages);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageCountOfCarIdCorrect(int carId)
        {
            var result = _carImagesDal.GetAll(ci => ci.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarMaxImageNumber);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarImageNameExists(string imagePath)
        {
            var result = _carImagesDal.GetAll(ci => ci.ImagePath == imagePath).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarImageAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
