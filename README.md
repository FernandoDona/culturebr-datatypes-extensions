
<a href="https://github.com/FernandoDona/culturebr-datatypes"></a>

<div align="center">

### Contém extensões para projetos de validação como o FluentValidation
<a href="https://www.nuget.org/packages/CultureBR.DataTypes"><img alt="Nuget" src="https://img.shields.io/nuget/v/CultureBR.DataTypes.Extensions.FluentValidation"></a> <br/>
`dotnet add package CultureBR.DataTypes.Extensions.FluentValidation`

</div>

- [O que é](#o-que-é)
- [Como Funciona](#como-funciona)
    - [Fluent Validation](#fluent-validation)

## O que é
É uma biblioteca que oferece extensões para bibliotecas de validação como o FluentValidation utilizando o projeto <a href="https://github.com/FernandoDona/culturebr-datatypes">CultureBR.DataTypes</a> para realizar as validações.
## Como funciona
As validações são feitas verificando se o input segue as regras de determinado tipo de dado.<br/>
Por padrão a validação é feita sem aceitar espaços em branco ou caracteres especiais fora da formatação correta. Isso é feito utilizando o parâmetro `Validation.Hard`.<br/>
Para a validação ser mais permissiva que permita caracteres em branco e caracteres especiais fora de ordem desde que a regra do tipo de dado seja respeitada é só utilizar o parâmetro `Validation.Soft`.<br/>
Caso opte por usar `Validation.Soft` é possível utilizar os formatadores da biblioteca <a href="https://github.com/FernandoDona/culturebr-datatypes">CultureBR.DataTypes</a> para realizar a formatação correta.
### Fluent Validation
Para extender a o FluentValidation e validar dados como CPF, CNPJ e CEP é bem simples.
Exemplo:
```csharp

    public PersonCPFValidator()
    {
        RuleFor(person => person.CPFString).ValidateCPF();
    }

    public PersonCNPJValidator()
    {
        RuleFor(person => person.CNPJString).ValidateCNPJ();
    }

    public PersonCEPValidator()
    {
        RuleFor(person => person.CEPString).ValidateCEP(Validation.Soft);
    }
```
