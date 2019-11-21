using System.Text.RegularExpressions;
using DSN.Common.Types;
using DSN.Identity.Domain;
using FluentValidation;


namespace DSN.Identity.Validation
{
    public class UserValidator: AbstractValidator<User>
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        public UserValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithErrorCode(Codes.InvalidEmail);
        }
    }
}
