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
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;
        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public IResult Add(Colour colour)
        {
            int saat = DateTime.Now.Hour;
            if (saat >= 8 && saat <= 10)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colourDal.Add(colour);
            return new SuccessResult(Messages.ColourAdded);
        }

        public IResult Delete(Colour colour)
        {
            int saat = DateTime.Now.Hour;
            if (saat >= 8 && saat <= 10)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colourDal.Delete(colour);
            return new SuccessResult(Messages.ColourDeleted);
        }

        public IDataResult<List<Colour>> GetAll()
        {
            int saat = DateTime.Now.Hour;
            if (saat >= 8 && saat <= 10)
            {
                return new ErrorDataResult<List<Colour>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(), Messages.ColoursListed);
        }

        public IDataResult<Colour> GetById(int colourId)
        {
            int saat = DateTime.Now.Hour;
            if (saat >= 8 && saat <= 10)
            {
                return new ErrorDataResult<Colour>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Colour>( _colourDal.Get(co => co.ColourId== colourId));
        }

        public IResult Update(Colour colour)
        {
            int saat = DateTime.Now.Hour;
            if (saat >= 8 && saat <= 10)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _colourDal.Update(colour);
            return new SuccessResult(Messages.ColourUpdated);
        }
    }
}
