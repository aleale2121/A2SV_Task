using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace BLOGAPP.Application.DTOs.Post.Validators;

public class IPostDtoValidator : AbstractValidator<IPostDTO>
{

    public IPostDTOValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} cannot exceed 100 characters.");

        RuleFor(p => p.Content)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}

