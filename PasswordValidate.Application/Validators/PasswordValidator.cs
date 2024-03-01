using FluentValidation;
using PasswordValidate.Application.Commands;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidate.Application.Validators
{
    public class PasswordValidator : AbstractValidator<PasswordCommand>
    {
        public PasswordValidator()
        {
            RuleFor(p => p.Password)
                .Must(PasswordIsNull)
                    .WithMessage("Senha não pode ser vazia")
                .Must(ValidateLength)
                    .WithMessage("Senha deve conter no mínimo 9 caracteres")
                .Must(ValidateNumber)
                    .WithMessage("Senha deve conter ao menos UM número")
                .Must(ValidateSpecial)
                    .WithMessage("Senha deve conter ao menos UM caractere especial: ! @ # $ % ^ & * ( ) - +")
                .Must(ValidateLowerCase)
                    .WithMessage("Senha deve conter ao menos UMA letra minúscula")
                .Must(ValidateUpperCase)
                    .WithMessage("Senha deve conter ao menos UMA letra maiúscula")
                .Must(ValidateDuplicate)
                    .WithMessage("Senha não deve conter caracteres duplicados")
                .Must(ValidateWhiteSpace)
                    .WithMessage("Senha não deve conter espaços em branco");
        }

        public bool PasswordIsNull(string password)
        {
            var isNull = password.Length == 0;

            return !isNull;
        }

        public bool ValidateLength(string password)
        {
            if (password.Length < 9)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ValidateNumber(string password)
        {
            var regex = new Regex(@"(?=.*[0-9])");

            return regex.IsMatch(password);
        }

        public bool ValidateSpecial(string password)
        {
            var regex = new Regex(@"(?=.*[!@#$%^&*()+-])");

            return regex.IsMatch(password);
        }

        public bool ValidateLowerCase(string password)
        {
            var regex = new Regex(@"(?=.*[a-z])");

            return regex.IsMatch(password);
        }

        public bool ValidateUpperCase(string password)
        {
            var regex = new Regex(@"(?=.*[A-Z])");

            return regex.IsMatch(password);
        }

        public bool ValidateDuplicate(string password)
        {
            var hasDuplicate = password.GroupBy(c => c).Any(g => g.Count() > 1);

            return !hasDuplicate;
        }

        public bool ValidateWhiteSpace(string password)
        {
            var hasWhiteSpace = password.Contains(" ");

            return !hasWhiteSpace;
        }
    }
}
