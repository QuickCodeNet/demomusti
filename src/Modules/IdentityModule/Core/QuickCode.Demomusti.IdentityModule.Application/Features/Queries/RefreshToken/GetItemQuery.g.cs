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
    public class GetItemRefreshTokenQuery : IRequest<Response<RefreshTokenDto>>
    {
        public int Id { get; set; }

        public GetItemRefreshTokenQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemRefreshTokenHandler : IRequestHandler<GetItemRefreshTokenQuery, Response<RefreshTokenDto>>
        {
            private readonly ILogger<GetItemRefreshTokenHandler> _logger;
            private readonly IRefreshTokenRepository _repository;
            public GetItemRefreshTokenHandler(ILogger<GetItemRefreshTokenHandler> logger, IRefreshTokenRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<RefreshTokenDto>> Handle(GetItemRefreshTokenQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}