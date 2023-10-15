using Microsoft.Extensions.Logging;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugPorter.API.Features.ReportBug.GitHub
{
    public class CreateGitHubIssueQuery
    {
        private readonly GitHubClient _gitHubClient;
        private readonly ILogger<CreateGitHubIssueQuery> _logger;

        public CreateGitHubIssueQuery(ILogger<CreateGitHubIssueQuery> logger, GitHubClient gitHubClient)
        {
            _logger = logger;
            _gitHubClient = gitHubClient;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");

            NewIssue newIssue = new NewIssue(newBug.Summary)
            {
                Body = newBug.Description
            };
            Issue createdIssue = await _gitHubClient.Issue.Create("Andre", "bugPorter", newIssue);

            _logger.LogInformation("Succesfully created GitHub issue {number}", createdIssue.Number);
            return new ReportedBug(
                createdIssue.Number.ToString(),
                createdIssue.Title,
                createdIssue.Body);
        }
    }
}
