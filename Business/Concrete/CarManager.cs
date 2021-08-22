using Business.Abstract;
using Business.Constants;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime); 
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<Car>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarsListedByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarsListedByColourId);
        }

        public IResult Update(Car car)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
