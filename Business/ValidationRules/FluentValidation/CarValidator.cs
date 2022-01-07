using Business.Constants;
using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2).WithMessage(Messages.CarNotAdded); //car's description should be min 2 char lenght.
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarNotAdded); // DailyPrice>0
        }
       
    }
}


