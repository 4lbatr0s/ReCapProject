using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
            {
                RuleFor(r => r.ReturnDate).NotNull().WithMessage(Messages.InvalidRental);
            }

    }
}
