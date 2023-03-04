using FluentValidation;
using FluentValidation.TestHelper;

namespace CultureBR.DataTypes.Extensions.FluentValidation.Tests;

public class CPFValidatorTests
{

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("634.343.245-06")] //invalid rule
    [InlineData(" 935.795.110-50")]
    [InlineData("9357.95.110-50")]
    public void ShouldBeInvalid_IfNotFollowsCPFRules(string? input)
    {
        var person = new Person { CPFString = input };
        var validator = new PersonCPFValidator();

        var result = validator.TestValidate(person);

        result.ShouldHaveValidationErrorFor(p => p.CPFString);
    }

    [Theory]
    [InlineData("462.038.820-38")]
    [InlineData("935.795.110-50")]
    [InlineData("93579511050")]
    public void ShouldBeValid_IfFollowsCPFRules(string? input)
    {
        var person = new Person { CPFString = input };
        var validator = new PersonCPFValidator();

        var result = validator.TestValidate(person);

        result.ShouldNotHaveValidationErrorFor(p => p.CPFString);
    }
}

public class PersonCPFValidator : AbstractValidator<Person>
{
    public PersonCPFValidator()
    {
        RuleFor(person => person.CPFString).ValidateCPF();
    }
}


public class Person
{
    public string? CPFString { get; set; }
    public string? CEPString { get; set; }
    public string? CNPJString { get; set; }
}