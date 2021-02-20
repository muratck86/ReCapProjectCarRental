using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.BodyType).NotEmpty();
            RuleFor(car => car.Plate).Must(CarPlateValid).WithMessage(Messages.InvalidCarPlate);

        }
        private bool CarPlateValid(string plate)
        {
            if (plate.Length < 7 || plate.Length > 9)
                return false;
            string cityCodeStr = plate.Substring(0, 2);
            int cityCode;
            try
            {
                cityCode = int.Parse(cityCodeStr);
            }
            catch (Exception e)
            {
                return false;
            }

            if (cityCode > 82)
                return false;
            if (!Char.IsLetter(plate[2]))
                return false;
            if (!(Char.IsDigit(plate[plate.Length - 1]) && Char.IsDigit(plate[plate.Length - 2])))
                return false;
            return true;
        }
    }
}
