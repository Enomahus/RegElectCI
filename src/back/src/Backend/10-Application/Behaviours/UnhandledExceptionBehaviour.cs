﻿using Application.Common.Interfaces.Services;
using Application.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Tools.Logging;

namespace Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse>(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService
    ) : Behaviour<TRequest, TResponse>
        where TRequest : notnull
        where TResponse : IResult
    {
        protected override async Task<TResponse> HandleRequest(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            var requestName = typeof(TRequest).Name;
            using var activity = ActivitySourceLog.CQRS.Start();

            try
            {
                return await next(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    ex,
                    "App Request: {Ip} {Name} Unhandled exception for request {@Request}",
                    currentUserService.ClientIp,
                    requestName,
                    request
                );

                activity.AddSerializedParameters(request);
                activity.SetException(ex);

                if (currentUserService.ClientIp is not null)
                {
                    activity?.AddTag("Ip", currentUserService.ClientIp);
                }
                throw;
            }
        }
    }
}
