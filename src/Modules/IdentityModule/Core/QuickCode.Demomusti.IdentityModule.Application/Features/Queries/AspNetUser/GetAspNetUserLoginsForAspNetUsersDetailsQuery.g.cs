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
    public class GetAspNetUserLoginsForAspNetUsersDetailsQuery : IRequest<Response<GetAspNetUserLoginsForAspNetUsersResponseDto>>
    {
        public string AspNetUsersId { get; set; }
        public string AspNetUserLoginsLoginProvider { get; set; }

        public GetAspNetUserLoginsForAspNetUsersDetailsQuery(string aspNetUsersId, string aspNetUserLoginsLoginProvider)
        {
            this.AspNetUsersId = aspNetUsersId;
            this.AspNetUserLoginsLoginProvider = aspNetUserLoginsLoginProvider;
        }

        public class GetAspNetUserLoginsForAspNetUsersDetailsHandler : IRequestHandler<GetAspNetUserLoginsForAspNetUsersDetailsQuery, Response<GetAspNetUserLoginsForAspNetUsersResponseDto>>
        {
            private readonly ILogger<GetAspNetUserLoginsForAspNetUsersDetailsHandler> _logger;
            private readonly IAspNetUserRepository _repository;
            public GetAspNetUserLoginsForAspNetUsersDetailsHandler(ILogger<GetAspNetUserLoginsForAspNetUsersDetailsHandler> logger, IAspNetUserRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetAspNetUserLoginsForAspNetUsersResponseDto>> Handle(GetAspNetUserLoginsForAspNetUsersDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetAspNetUserLoginsForAspNetUsersDetailsAsync(request.AspNetUsersId, request.AspNetUserLoginsLoginProvider);
                return returnValue.ToResponse();
            }
        }
    }
}