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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.AspNetUserClaim;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.AspNetUserClaim
{
    public class TotalCountAspNetUserClaimQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetUserClaimQuery()
        {
        }

        public class TotalCountAspNetUserClaimHandler : IRequestHandler<TotalCountAspNetUserClaimQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetUserClaimHandler> _logger;
            private readonly IAspNetUserClaimRepository _repository;
            public TotalCountAspNetUserClaimHandler(ILogger<TotalCountAspNetUserClaimHandler> logger, IAspNetUserClaimRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetUserClaimQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}