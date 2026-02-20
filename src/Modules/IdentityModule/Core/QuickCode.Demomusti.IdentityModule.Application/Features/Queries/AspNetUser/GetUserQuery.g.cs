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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.AspNetUser;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.AspNetUser
{
    public class GetUserQuery : IRequest<Response<GetUserResponseDto>>
    {
        public string? AspNetUserEmail { get; set; }

        public GetUserQuery(string? aspNetUserEmail)
        {
            this.AspNetUserEmail = aspNetUserEmail;
        }

        public class GetUserHandler : IRequestHandler<GetUserQuery, Response<GetUserResponseDto>>
        {
            private readonly ILogger<GetUserHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetUserHandler(ILogger<GetUserHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetUserResponseDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetUserAsync(request.AspNetUserEmail);
                return returnValue.ToResponse();
            }
        }
    }
}