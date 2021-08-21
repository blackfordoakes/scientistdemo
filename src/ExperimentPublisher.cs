using System.Threading.Tasks;
using GitHub;
using Microsoft.Extensions.Logging;

namespace ScientistDemo
{
    internal class ExperimentPublisher : IResultPublisher
    {
        private readonly ILogger<ExperimentPublisher> _logger;

        public ExperimentPublisher(ILogger<ExperimentPublisher> log)
        {
            _logger = log;
        }

        public Task Publish<T, TClean>(Result<T, TClean> result)
        {
            _logger.LogInformation($"Publishing results for experiment '{result.ExperimentName}'");
            _logger.LogInformation($"Result: {(result.Matched ? "MATCH" : "MISMATCH")}");
            _logger.LogInformation($"Control value: {result.Control.Value}");
            _logger.LogInformation($"Control duration: {result.Control.Duration}");

            foreach (var observation in result.Candidates)
            {
                _logger.LogInformation($"Candidate name: {observation.Name}");
                _logger.LogInformation($"Candidate value: {observation.Value}");
                _logger.LogInformation($"Candidate duration: {observation.Duration}");
            }

            if (result.Mismatched)
            {
                // if the answers of our methods don't match, do something like log to db
            }

            return Task.FromResult(0);
        }
    }
}
