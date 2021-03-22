using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.DailyPrice).NotEmpty();
        }
    }
}
