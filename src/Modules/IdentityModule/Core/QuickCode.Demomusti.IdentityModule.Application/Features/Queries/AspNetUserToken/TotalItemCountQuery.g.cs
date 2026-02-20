using System;
using System.Linq;
using QuickCode.Demomusti.Common.Mediator;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using QuickCode.Demomusti.Common.Models;
using QuickCode.Demomusti.IdentityModule.Domain.Entities;
using QuickCode.Demomusti.IdentityModule.Application.Interfaces.Repositories;
using QuickCode.Demomusti.IdentityModule.Application.Dtos.AspNetUserToken;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.AspNetUserToken
{
    public class TotalCountAspNetUserTokenQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetUserTokenQuery()
        {
        }

        public class TotalCountAspNetUserTokenHandler : IRequestHandler<TotalCountAspNetUserTokenQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetUserTokenHandler> _logger;
            private readonly IAspNetUserTokenRepository _repository;
            public TotalCountAspNetUserTokenHandler(ILogger<TotalCountAspNetUserTokenHandler> logger, IAspNetUserTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetUserTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}