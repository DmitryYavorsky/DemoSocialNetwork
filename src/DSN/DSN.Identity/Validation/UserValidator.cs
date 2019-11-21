using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSN.Identity.Domain;
using FluentValidation;


namespace DSN.Identity.Validation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor()
        }
    }
}
