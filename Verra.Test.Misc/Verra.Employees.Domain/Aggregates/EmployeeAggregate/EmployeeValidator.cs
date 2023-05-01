using FluentValidation;

namespace Verra.Employees.Domain.Aggregates.EmployeeAggregate
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).Length(1, 15);

            RuleFor(x => x.LastName).Length(1, 15);
        }
    }
}