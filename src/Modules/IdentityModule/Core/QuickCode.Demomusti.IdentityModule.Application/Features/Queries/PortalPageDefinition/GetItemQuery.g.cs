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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.PortalPageDefinition;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.PortalPageDefinition
{
    public class GetItemPortalPageDefinitionQuery : IRequest<Response<PortalPageDefinitionDto>>
    {
        public string Key { get; set; }

        public GetItemPortalPageDefinitionQuery(string key)
        {
            this.Key = key;
        }

        public class GetItemPortalPageDefinitionHandler : IRequestHandler<GetItemPortalPageDefinitionQuery, Response<PortalPageDefinitionDto>>
        {
            private readonly ILogger<GetItemPortalPageDefinitionHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetItemPortalPageDefinitionHandler(ILogger<GetItemPortalPageDefinitionHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<PortalPageDefinitionDto>> Handle(GetItemPortalPageDefinitionQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Key);
                return returnValue.ToResponse();
            }
        }
    }
}