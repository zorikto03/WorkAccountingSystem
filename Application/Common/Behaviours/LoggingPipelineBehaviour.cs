using Domain.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours;

public class LoggingPipelineBehaviour<TRequest, TResponce>
    : IPipelineBehavior<TRequest, TResponce>
    where TResponce : Result
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponce>> _logger;

    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponce>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponce> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponce> next,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting request {@RequestName}, {@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        var result = await next();

        if (result.IsFailure)
            _logger.LogError("Request failure {@RequestName}, {@Error},{@DateTimeUtc}",
                typeof(TRequest).Name,
                result.Error,
                DateTime.UtcNow);

        _logger.LogInformation("Completed request {@RequestName}, {@DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        return result;
    }
}
