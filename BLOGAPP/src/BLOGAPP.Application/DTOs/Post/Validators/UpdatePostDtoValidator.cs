using FluentValidation;
using BLOGAPP.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.DTOs.Post.Validators;

public class UpdatePostDtoValidator : AbstractValidator<PostUpdateDTO>
{

    public UpdatePostDtoValidator()
    {
        Include(new IPostDtoValidator());
        
        RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        RuleFor(p => p.UpdatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(20).WithMessage("{PropertyName} cannot exceed 100 characters.");
    }
}

