using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColourService
    {
        IResult Add(Colour colour);
        IResult Update(Colour colour);
        IResult Delete(Colour colour);
        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> GetById(int colourId);
    }
}
