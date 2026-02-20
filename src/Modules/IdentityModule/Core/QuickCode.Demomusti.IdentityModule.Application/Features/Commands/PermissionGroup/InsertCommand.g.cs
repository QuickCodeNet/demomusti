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
    public class InsertPermissionGroupCommand : IRequest<Response<PermissionGroupDto>>
    {
        public PermissionGroupDto request { get; set; }

        public InsertPermissionGroupCommand(PermissionGroupDto request)
        {
            this.request = request;
        }

        public class InsertPermissionGroupHandler : IRequestHandler<InsertPermissionGroupCommand, Response<PermissionGroupDto>>
        {
            private readonly ILogger<InsertPermissionGroupHandler> _logger;
            private readonly IPermissionGroupRepository _repository;
            public InsertPermissionGroupHandler(ILogger<InsertPermissionGroupHandler> logger, IPermissionGroupRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<PermissionGroupDto>> Handle(InsertPermissionGroupCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}