using Ardalis.Result;
using Ardalis.SharedKernel;

namespace BLOG.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
