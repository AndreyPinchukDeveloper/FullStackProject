using Microsoft.Extensions.Logging;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugPorter.API.Features.ReportBug.GitHub
{
    public class CreateGitHubIssueCommand
    {
        private readonly GitHubClient _gitHubClient;
        private readonly ILogger<CreateGitHubIssueCommand> _logger;
        private readonly GitHubRepositoryOptions _gitHubRepositoryOptions;

        public CreateGitHubIssueCommand(GitHubClient gitHubClient, ILogger<CreateGitHubIssueCommand> logger, GitHubRepositoryOptions gitHubRepositoryOptions)
        {
            _gitHubClient = gitHubClient;
            _logger = logger;
            _gitHubRepositoryOptions = gitHubRepositoryOptions;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");

            NewIssue newIssue = new NewIssue(newBug.Summary)
            {
                Body = newBug.Description
            };
            Issue createdIssue = await _gitHubClient.Issue.Create(_gitHubRepositoryOptions.Owner, _gitHubRepositoryOptions.Name, newIssue);

            _logger.LogInformation("Succesfully created GitHub issue {number}", createdIssue.Number);
            return new ReportedBug(
                createdIssue.Number.ToString(),
                createdIssue.Title,
                createdIssue.Body);
        }
    }
}
