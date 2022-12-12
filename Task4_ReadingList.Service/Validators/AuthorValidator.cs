using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.Service.Dto;

namespace Task4_ReadingList.Service.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .Length(2, 20).WithMessage("First Name must be between 2 - 20 characters")
                .Matches("^[a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź]+(([',. -][a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź])?[a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź]*)*$").WithMessage("First Name cannot contain numbers");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .Length(2, 20).WithMessage("Last Name must be between 2 - 20 characters")
                .Matches("^[a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź]+(([',. -][a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź])?[a-zA-ZĄĆĘŁŃÓŚŻŹąćęłńóśżź]*)*$").WithMessage("Last Name cannot contain numbers");

        }
    }
}
