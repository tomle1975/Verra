using FluentAssertions;
using Verra.Employees.Domain.Aggregates.EmployeeAggregate;
using Xunit;

namespace Verra.Employees.Test.Domain.Aggregates.EmployeeAggregate
{
    public class EmployeeValidatorTest
    {
        private readonly EmployeeValidator validator = new();

        [Theory]
        [InlineData("Tom", "Le", true)]
        [InlineData("TomTomTomTomTomTom", "Le", false)]
        public void Validate_ReturnsResult_WhenValidated(string firstName, string lastName, bool isValid)
        {
            var employee = new Employee(firstName, lastName, "Engineering", Guid.NewGuid(), "123 Main Street, Marietta, GA 30215", DateTime.Parse("02/09/1975"), "Male", "SW Engineer", DateTime.Now, 100000.00);
            var result = validator.Validate(employee);
            result.IsValid.Should().Be(isValid);
        }
    }
}