using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentValidator : AbstractValidator<Rent>
    {
        public RentValidator()
        {
            RuleFor(rent => rent.CarId).NotEmpty();
        }
    }
}
