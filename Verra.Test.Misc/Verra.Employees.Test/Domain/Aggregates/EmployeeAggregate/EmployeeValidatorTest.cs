using FluentAssertions;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Xunit;

namespace Verra.Employees.Test.Domain.Aggregates.EmployeeAggregate;

public class EmployeeValidatorTest
{
    private readonly EmployeeValidator validator = new();

    [Theory]
    [InlineData("Tom", "Le", true)]
    [InlineData("TomTomTomTomTomTom", "Le", false)]
    public void Validate_ReturnsResult_WhenValidated(string firstName, string lastName, bool isValid)
    {
        var employeeId = Guid.NewGuid();
        var employee = new Employee(
            Guid.NewGuid(),
            firstName,
            lastName,
            "Engineering",
            employeeId,
            new Address("123 Main Street", null, "Powder Springs", "GA", "30127", "USA"),
            DateTime.Parse("02/09/1975"), 
            Gender.Male,
            new List<EmployeePosition>
            {
                new(Guid.NewGuid(), employeeId, DateTime.Now, "Sr. Software Engineer", 100000.00)
            });

        var result = validator.Validate(employee);
        result.IsValid.Should().Be(isValid);
    }
}