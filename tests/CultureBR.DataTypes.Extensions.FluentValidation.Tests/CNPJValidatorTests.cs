using FluentValidation;
using FluentValidation.TestHelper;

namespace CultureBR.DataTypes.Extensions.FluentValidation.Tests;

public class CNPJValidatorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("86.456.345/0002-14")] //invalid rule
    [InlineData(" 69.637.054/0001-69")]
    [InlineData("69.637.0540/001-69")]
    public void ShouldBeInvalid_IfNotFollowsCNPJRules(string? input)
    {
        var person = new Person { CNPJString = input };
        var validator = new PersonCNPJValidator();

        var result = validator.TestValidate(person);

        result.ShouldHaveValidationErrorFor(p => p.CNPJString);
    }

    [Theory]
    [InlineData("23.657.565/0001-41")]
    [InlineData("69.637.054/0001-69")]
    public void ShouldBeValid_IfFollowsCNPJRules(string? input)
    {
        var person = new Person { CNPJString = input };
        var validator = new PersonCNPJValidator();

        var result = validator.TestValidate(person);

        result.ShouldNotHaveValidationErrorFor(p => p.CNPJString);
    }
}

public class PersonCNPJValidator : AbstractValidator<Person>
{
    public PersonCNPJValidator()
    {
        RuleFor(person => person.CNPJString).ValidateCNPJ();
    }
}
