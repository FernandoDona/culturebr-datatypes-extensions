using FluentValidation;
using System;
using System.Globalization;

namespace CultureBR.DataTypes.Extensions.FluentValidation
{
    public static class DataTypesValidationExtensions
    {
        public static IRuleBuilderOptions<T, string?> ValidateCPF<T>(this IRuleBuilderInitial<T, string?> ruleBuilder, ValidationLevel validationLevel = ValidationLevel.Hard)
        {
            return ruleBuilder.Must(input => CPF.IsValid(input, validationLevel))
                .WithMessage(IsBrazilCulture() ? "{PropertyName} {PropertyValue} não é válido." : "{PropertyName} {PropertyValue} is not valid.")
                .WithErrorCode("InvalidCPF");
        }

        public static IRuleBuilderOptions<T, string?> ValidateCNPJ<T>(this IRuleBuilderInitial<T, string?> ruleBuilder, ValidationLevel validationLevel = ValidationLevel.Hard)
        {
            return ruleBuilder.Must(input => CNPJ.IsValid(input, validationLevel))
                .WithMessage(IsBrazilCulture() ? "{PropertyName} {PropertyValue} não é válido." : "{PropertyName} {PropertyValue} is not valid.")
                .WithErrorCode("InvalidCNPJ"); ;
        }

        public static IRuleBuilderOptions<T, string?> ValidateCEP<T>(this IRuleBuilderInitial<T, string?> ruleBuilder, ValidationLevel validationLevel = ValidationLevel.Hard)
        {
            return ruleBuilder.Must(input => CEP.IsValid(input, validationLevel))
                .WithMessage(IsBrazilCulture() ? "{PropertyName} {PropertyValue} não é válido." : "{PropertyName} {PropertyValue} is not valid.")
                .WithErrorCode("InvalidCEP");
        }

        private static bool IsBrazilCulture()
        {
            return CultureInfo.CurrentUICulture.Name == "pt-BR";
        }
    }
}
