using BLOG.Web.ContributorEndpoints;

namespace BLOG.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}
