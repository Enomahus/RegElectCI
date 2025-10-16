using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces.Services;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Tools.Logging;

namespace Application.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : notnull
    {
        protected readonly string _name;
        protected readonly ILogger<TRequest> _logger;
        protected readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _name = GetType().Name;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            using var activity = ActivitySourceLog.CQRS.Start();

            var requestName = typeof(TRequest).Name;
            var userId = /*_currentUserService.UserId.ToString();*/
                "Anonymous";

            _logger.LogInformation(
                "App Request: {Ip} {Name} {@UserId} {@Request}",
                /*_currentUserService.ClientIp*/"",
                requestName,
                userId,
                request
            );

            return Task.CompletedTask;
        }
    }
}
