using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BugPorter.API.Features.ReportBug.GitHub;
using BugPorter.API.Features.ReportBug;

namespace BugPorter.API
{
    public class ReportBugFunction
    {
        private readonly CreateGitHubIssueQuery _createGitHubIssueQuery;
        private readonly ILogger<ReportBugFunction> _logger;

        public ReportBugFunction(CreateGitHubIssueQuery createGitHubIssueQuery, ILogger<ReportBugFunction> logger)
        {
            _createGitHubIssueQuery = createGitHubIssueQuery;
            _logger = logger;
        }

        [FunctionName("ReportBugFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] HttpRequest req)
        {
            NewBug newBug = new NewBug();
            return new OkResult();
        }
    }
}
