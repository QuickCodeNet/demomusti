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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.AspNetUserRole;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.AspNetUserRole
{
    public class TotalCountAspNetUserRoleQuery : IRequest<Response<int>>
    {
        public TotalCountAspNetUserRoleQuery()
        {
        }

        public class TotalCountAspNetUserRoleHandler : IRequestHandler<TotalCountAspNetUserRoleQuery, Response<int>>
        {
            private readonly ILogger<TotalCountAspNetUserRoleHandler> _logger;
            private readonly IAspNetUserRoleRepository _repository;
            public TotalCountAspNetUserRoleHandler(ILogger<TotalCountAspNetUserRoleHandler> logger, IAspNetUserRoleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(TotalCountAspNetUserRoleQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.CountAsync();
                return returnValue.ToResponse();
            }
        }
    }
}