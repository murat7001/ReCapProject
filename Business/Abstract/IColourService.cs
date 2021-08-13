using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColourService
    {
        void Add(Colour colour);
        void Update(Colour colour);
        void Delete(Colour colour);
        List<Colour> GetAll();
        Colour GetById(int colourId);
    }
}
