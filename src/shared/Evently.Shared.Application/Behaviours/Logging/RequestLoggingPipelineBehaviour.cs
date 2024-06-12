using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Evently.Shared.Application.Behaviours.Logging;

internal sealed class RequestLoggingPipelineBehaviour<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehaviour<TRequest, TResponse>> logger
) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var moduleName = GetModuleName(typeof(TRequest).FullName ?? throw new NullReferenceException("Request full name cannot be null."));
        var requestName = typeof(TRequest).Name;

        using (LogContext.PushProperty("Module", moduleName))
        {
            logger.LogInformation("Processing request {requestName}", requestName);

            try
            {
                var response = await next();

                logger.LogInformation("Completed request {requestName}", requestName);

                return response;
            }
            catch (Exception exception)
            {
                using (LogContext.PushProperty("Error", exception.Message, destructureObjects: true))
                    logger.LogError(exception, "Completed request {requestName} with error", requestName);

                throw;
            }
        }
    }

    private static string GetModuleName(string requestName) =>
        requestName.Split('.')[2];
}