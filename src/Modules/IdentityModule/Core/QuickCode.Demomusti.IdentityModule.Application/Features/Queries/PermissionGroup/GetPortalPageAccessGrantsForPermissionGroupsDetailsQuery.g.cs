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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.PermissionGroup;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.PermissionGroup
{
    public class GetPortalPageAccessGrantsForPermissionGroupsDetailsQuery : IRequest<Response<GetPortalPageAccessGrantsForPermissionGroupsResponseDto>>
    {
        public string PermissionGroupsName { get; set; }
        public string PortalPageAccessGrantsPermissionGroupName { get; set; }

        public GetPortalPageAccessGrantsForPermissionGroupsDetailsQuery(string permissionGroupsName, string portalPageAccessGrantsPermissionGroupName)
        {
            this.PermissionGroupsName = permissionGroupsName;
            this.PortalPageAccessGrantsPermissionGroupName = portalPageAccessGrantsPermissionGroupName;
        }

        public class GetPortalPageAccessGrantsForPermissionGroupsDetailsHandler : IRequestHandler<GetPortalPageAccessGrantsForPermissionGroupsDetailsQuery, Response<GetPortalPageAccessGrantsForPermissionGroupsResponseDto>>
        {
            private readonly ILogger<GetPortalPageAccessGrantsForPermissionGroupsDetailsHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public GetPortalPageAccessGrantsForPermissionGroupsDetailsHandler(ILogger<GetPortalPageAccessGrantsForPermissionGroupsDetailsHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetPortalPageAccessGrantsForPermissionGroupsResponseDto>> Handle(GetPortalPageAccessGrantsForPermissionGroupsDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetPortalPageAccessGrantsForPermissionGroupsDetailsAsync(request.PermissionGroupsName, request.PortalPageAccessGrantsPermissionGroupName);
                return returnValue.ToResponse();
            }
        }
    }
}