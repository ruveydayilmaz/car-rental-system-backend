using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("rental.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var carList = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            
            foreach (var car in carList)
            {
                if (car.ReturnDate == null)
                {
                    return new ErrorResult(Messages.CarNotAvailable);
                }
            }
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);

        }

        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult(Messages.RentalDeleted);
        }

        [SecuredOperation("rental.update,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.RentalUpdated);
        }
      
        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());

        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
