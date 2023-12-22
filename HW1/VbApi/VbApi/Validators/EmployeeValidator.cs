using FluentValidation;

using VbApi.Controllers;


namespace APIValidation.Demo;



public class EmployeeValidator: AbstractValidator<Employee>{


    public EmployeeValidator(){

        RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Invalid Name")
        .NotEmpty()
        .WithMessage("Invalid Name")
        .MaximumLength(250)
        .WithMessage("Invalid Name")
        .MinimumLength(10)
        .WithMessage("Invalid Name");

        RuleFor(x => x.DateOfBirth)
        .NotNull()
        .WithMessage("Birthdate is not valid")
        .NotEmpty()
        .WithMessage("Birthdate is not valid")
        .Must(BeValidBirthDate)
        .WithMessage("Birthdate is not valid");

        RuleFor(x => x.Email)
        .EmailAddress()
        .WithMessage("Email address is not valid.");

        RuleFor(x => x.Phone)
            .Matches(@"^\+90\d{10}$")   // Phone number validation for numbers in Turkey Format : {+90xxx xxx xx xx}
            .WithMessage("Phone is not valid.");

        RuleFor(x => x.HourlySalary)
            .InclusiveBetween(50, 400)
            .WithMessage("Hourly salary does not fall within allowed range.");

        RuleFor(x => x)
            .Must(MinLegalSalaryRequired)
            .WithMessage("Minimum hourly salary is not valid.");

            



    }

    private bool BeValidBirthDate(DateTime dateOfBirth)
        {
            var minAllowedBirthDate = DateTime.Today.AddYears(-65);
            return minAllowedBirthDate < dateOfBirth;
        }

    private bool MinLegalSalaryRequired(Employee employee)
    {
        var dateBeforeThirtyYears = DateTime.Today.AddYears(-30);
        var isOlderThanThirtyYears = employee.DateOfBirth <= dateBeforeThirtyYears;
        

        return isOlderThanThirtyYears ? employee.HourlySalary >= 200 : employee.HourlySalary >= 50;
    }

    


}



