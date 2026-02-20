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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.PortalMenu;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.PortalMenu
{
    public class DeletePortalMenuItemsWithModuleNameCommand : IRequest<Response<int>>
    {
        public string PortalMenuKey { get; set; }

        public DeletePortalMenuItemsWithModuleNameCommand(string portalMenuKey)
        {
            this.PortalMenuKey = portalMenuKey;
        }

        public class DeletePortalMenuItemsWithModuleNameHandler : IRequestHandler<DeletePortalMenuItemsWithModuleNameCommand, Response<int>>
        {
            private readonly ILogger<DeletePortalMenuItemsWithModuleNameHandler> _logger;
            private readonly IPortalMenuRepository _repository;
            public DeletePortalMenuItemsWithModuleNameHandler(ILogger<DeletePortalMenuItemsWithModuleNameHandler> logger, IPortalMenuRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<int>> Handle(DeletePortalMenuItemsWithModuleNameCommand request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.DeletePortalMenuItemsWithModuleNameAsync(request.PortalMenuKey);
                return returnValue.ToResponse();
            }
        }
    }
}