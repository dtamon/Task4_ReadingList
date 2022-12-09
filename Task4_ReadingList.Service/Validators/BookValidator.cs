using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4_ReadingList.Service.Dto;

namespace Task4_ReadingList.Service.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(2, 50).WithMessage("Title must be between 2-20 characters");

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("Author is required");
        }
    }
}
