using FluentValidation;
using BLOGAPP.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.DTOs.Post.Validators;

public class CreatePostDtoValidator : AbstractValidator<PostCreateDTO>
{

    public CreatePostDtoValidator()
    {
        Include(new IPostDtoValidator());
        RuleFor(p => p.CreatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 100 characters.");
    }
}

