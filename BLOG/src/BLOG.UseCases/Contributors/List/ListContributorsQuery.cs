using Ardalis.Result;
using Ardalis.SharedKernel;

namespace BLOG.UseCases.Contributors.List;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
