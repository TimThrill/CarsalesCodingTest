using Carsales.CodingTest.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carsales.CodingTest.Application.Validations
{
    public class CreateCarCommandValidator: AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.DoorCount).GreaterThan(0).WithMessage("Doors number must be greater than zero");
            RuleFor(c => c.WheelCount).GreaterThan(0).WithMessage("Wheels number must be greater than zero");
        }
    }
}
