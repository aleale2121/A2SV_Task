﻿using Ardalis.Result;
using Ardalis.SharedKernel;

namespace BLOG.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
