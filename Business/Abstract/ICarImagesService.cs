using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll(Expression<Func<CarImages, bool>> filter = null);
        IDataResult<CarImages> GetById(int imagesId);
        IResult Add(IFormFile file,CarImages carImages);
        IResult Update(IFormFile file, CarImages carImages);
        IResult Delete(CarImages carImages);
    }
}
