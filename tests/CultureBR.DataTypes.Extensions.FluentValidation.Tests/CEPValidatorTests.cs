using FluentValidation;
using FluentValidation.TestHelper;

namespace CultureBR.DataTypes.Extensions.FluentValidation.Tests;

public class CEPValidatorTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("00154000")]
    [InlineData("00154-000")]
    public void ShouldBeInvalid_IfNotFollowsCEPRules(string? input)
    {
        var person = new Person { CEPString = input };
        var validator = new PersonCEPValidator();

        var result = validator.TestValidate(person);

        result.ShouldHaveValidationErrorFor(p => p.CEPString);
    }

    [Theory]
    [InlineData("02154000")]
    [InlineData("93154-000")]
    public void ShouldBeValid_IfFollowsCEPRules(string? input)
    {
        var person = new Person { CEPString = input };
        var validator = new PersonCEPValidator();

        var result = validator.TestValidate(person);

        result.ShouldNotHaveValidationErrorFor(p => p.CEPString);
    }
}

public class PersonCEPValidator : AbstractValidator<Person>
{
    public PersonCEPValidator()
    {
        RuleFor(person => person.CEPString).ValidateCEP();
    }
}
