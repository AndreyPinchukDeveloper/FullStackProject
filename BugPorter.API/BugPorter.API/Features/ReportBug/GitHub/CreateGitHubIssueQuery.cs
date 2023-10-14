using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugPorter.API.Features.ReportBug.GitHub
{
    public class CreateGitHubIssueQuery
    {
        private readonly ILogger<CreateGitHubIssueQuery> _logger;

        public CreateGitHubIssueQuery(ILogger<CreateGitHubIssueQuery> logger)
        {
            _logger = logger;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");
            ReportedBug reportedBug = new ReportedBug("1", newBug.Summary, newBug.Description);
            _logger.LogInformation("Succesfully created GitHub issue {id}", reportedBug.Id);
            return reportedBug;
        }
    }
}
