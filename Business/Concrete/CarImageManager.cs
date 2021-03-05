using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("carImage.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage));

            if (result != null)
            {
                return result;
            }

            carImage.ImageFile = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carImage.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {

            FileHelper.Delete(carImage.ImageFile);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetByCar(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageEmpty(id));
        }

        [SecuredOperation("carImage.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = Environment.CurrentDirectory + _carImageDal.Get(i => i.Id == carImage.Id).ImageFile;
            carImage.ImageFile = FileHelper.Update(oldpath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }

        private IResult CheckCarImageLimit(CarImage carImage)
        {
            if (_carImageDal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageAddingError);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageEmpty(int carId)
        {
            string path = Environment.CurrentDirectory + @"\CarImages\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return _carImageDal.GetAll(c => c.CarId == carId);
            }

            return new List<CarImage> { new CarImage { CarId = carId, ImageFile = path, ImageDate = DateTime.Now } };
        }
    }
}

