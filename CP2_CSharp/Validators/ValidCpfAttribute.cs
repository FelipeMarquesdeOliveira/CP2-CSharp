using System.ComponentModel.DataAnnotations;

namespace CP2_CSharp.Validators;

public class ValidCpfAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string cpf || string.IsNullOrWhiteSpace(cpf))
            return ValidationResult.Success;

        cpf = cpf.Trim().Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return new ValidationResult(ErrorMessage ?? "CPF deve ter 11 dígitos");

        if (cpf.All(c => c == cpf[0]))
            return new ValidationResult(ErrorMessage ?? "CPF inválido");

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf[..9];
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        string digito = resto.ToString();
        tempCpf += digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        digito += resto.ToString();

        if (!cpf.EndsWith(digito))
            return new ValidationResult(ErrorMessage ?? "CPF inválido");

        return ValidationResult.Success;
    }
}
