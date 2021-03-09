using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);
        IDataResult<CarImage> GetById(int imagesId);
        IResult Add(IFormFile file,CarImage carImages);
        IResult Update(IFormFile file, CarImage carImages);
        IResult Delete(CarImage carImages);
    }
}
