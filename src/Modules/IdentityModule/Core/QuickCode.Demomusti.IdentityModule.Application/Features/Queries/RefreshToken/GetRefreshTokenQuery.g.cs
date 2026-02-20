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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.RefreshToken;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.RefreshToken
{
    public class GetRefreshTokenQuery : IRequest<Response<GetRefreshTokenResponseDto>>
    {
        public string RefreshTokenToken { get; set; }

        public GetRefreshTokenQuery(string refreshTokenToken)
        {
            this.RefreshTokenToken = refreshTokenToken;
        }

        public class GetRefreshTokenHandler : IRequestHandler<GetRefreshTokenQuery, Response<GetRefreshTokenResponseDto>>
        {
            private readonly ILogger<GetRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public GetRefreshTokenHandler(ILogger<GetRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetRefreshTokenResponseDto>> Handle(GetRefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetRefreshTokenAsync(request.RefreshTokenToken);
                return returnValue.ToResponse();
            }
        }
    }
}