using FluentValidation;

using VbApi.Controllers;


namespace APIValidation.Demo;


public class StaffValidator: AbstractValidator<Staff>{



        public StaffValidator(){


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Invalid Name.")
                .NotNull()
                .WithMessage("Invalid Name.")
                .MaximumLength(250)
                .WithMessage("Invalid Name.")
                .MinimumLength(10)
                .WithMessage("Invalid Name.");


            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email address is not valid.");


            RuleFor(x => x.Phone)
                .Matches(@"^\+90\d{10}$")        // Phone number validation for numbers in Turkey Format : {+90xxx xxx xx xx}
                .WithMessage("Phone is not valid.");

            RuleFor(x => x.HourlySalary)
            .InclusiveBetween(50, 400)
            .WithMessage("Hourly salary does not fall within allowed range.");





        }


 }

