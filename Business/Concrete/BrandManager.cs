using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

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
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Brand>( _brandDal.Get(b => b.BrandId == brandId));
        }

        public IResult Update(Brand brand)
        {
            int saat = DateTime.Now.Hour;
            if (saat < 8 || saat > 17)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
