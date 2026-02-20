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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.ApiMethodDefinition;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.ApiMethodDefinition
{
    public class DeleteApiMethodDefinitionCommand : IRequest<Response<bool>>
    {
        public ApiMethodDefinitionDto request { get; set; }

        public DeleteApiMethodDefinitionCommand(ApiMethodDefinitionDto request)
        {
            this.request = request;
        }

        public class DeleteApiMethodDefinitionHandler : IRequestHandler<DeleteApiMethodDefinitionCommand, Response<bool>>
        {
            private readonly ILogger<DeleteApiMethodDefinitionHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public DeleteApiMethodDefinitionHandler(ILogger<DeleteApiMethodDefinitionHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteApiMethodDefinitionCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}