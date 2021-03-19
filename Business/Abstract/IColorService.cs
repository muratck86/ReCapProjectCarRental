using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService : IVehicleRentalBaseService<Color>
    {
        IResult AddTransactionalTest(Color color); //A mock method to show how transaction aspect is used
        IDataResult<List<Color>> GetByName(string colorName);
    }
}
