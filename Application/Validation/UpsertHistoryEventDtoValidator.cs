using FluentValidation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Validation
{
    public class UpsertHistoryEventDtoValidator : AbstractValidator<UpsertHistoryEventDto>
    {
        public UpsertHistoryEventDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is Required")
                .MinimumLength(3)
                .WithMessage("Name must be at leat 3 characters long")
                .MaximumLength(100)
                .WithMessage("Name must have less than 100 characters");

            RuleFor(x => x.ShortDescription)
                .NotEmpty()
                .WithMessage("Short description is Required")
                .MaximumLength(100)
                .WithMessage("Short description must have less than 100 characters");

            RuleFor(x => x.ShortDescription)
                .NotEmpty()
                .WithMessage("Long description is required")
                .MaximumLength(1000)
                .WithMessage("Long description must have less than 1000 characters");

            RuleFor(x => x.DateType)
                .IsInEnum();

            RuleFor(x => x.EventTimeStart)
                .NotEmpty();

            RuleFor(x => x.IsBeforeCommonEra)
                .NotEmpty();
        }
    }
}
