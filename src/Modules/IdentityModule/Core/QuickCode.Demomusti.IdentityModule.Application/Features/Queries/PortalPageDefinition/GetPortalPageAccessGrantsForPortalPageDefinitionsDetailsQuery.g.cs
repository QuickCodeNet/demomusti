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
    public class GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery : IRequest<Response<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>
    {
        public string PortalPageDefinitionsKey { get; set; }
        public string PortalPageAccessGrantsPermissionGroupName { get; set; }

        public GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery(string portalPageDefinitionsKey, string portalPageAccessGrantsPermissionGroupName)
        {
            this.PortalPageDefinitionsKey = portalPageDefinitionsKey;
            this.PortalPageAccessGrantsPermissionGroupName = portalPageAccessGrantsPermissionGroupName;
        }

        public class GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler : IRequestHandler<GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery, Response<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler> _logger;
            private readonly IPortalPageDefinitionRepository _repository;
            public GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler(ILogger<GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsHandler> logger, IPortalPageDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetPortalPageAccessGrantsForPortalPageDefinitionsResponseDto>> Handle(GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsForPortalPageDefinitionsDetailsAsync(request.PortalPageDefinitionsKey, request.PortalPageAccessGrantsPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}