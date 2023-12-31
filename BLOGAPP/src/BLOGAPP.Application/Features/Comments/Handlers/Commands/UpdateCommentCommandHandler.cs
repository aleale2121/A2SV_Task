﻿using AutoMapper;
using BLOGAPP.Application.DTOs.Comment.Validators;
using BLOGAPP.Application.Exceptions;
using BLOGAPP.Application.Features.Comments.Requests.Commands;
using BLOGAPP.Application.Contracts.Persistence;
using BLOGAPP.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Features.Comments.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CommentDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var comment = await _unitOfWork.CommentRepository.Get(request.CommentDto.Id);

        if (comment is null)
            throw new NotFoundException(nameof(comment), request.CommentDto.Id);

        _mapper.Map(request.CommentDto, comment);

        await _unitOfWork.CommentRepository.Update(comment);
        await _unitOfWork.Save();
        return Unit.Value;
    }
}

