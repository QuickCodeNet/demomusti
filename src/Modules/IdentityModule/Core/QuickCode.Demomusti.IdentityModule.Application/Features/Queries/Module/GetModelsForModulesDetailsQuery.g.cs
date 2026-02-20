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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.Module;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.Module
{
    public class GetModelsForModulesDetailsQuery : IRequest<Response<GetModelsForModulesResponseDto>>
    {
        public string ModulesName { get; set; }
        public string ModelsName { get; set; }

        public GetModelsForModulesDetailsQuery(string modulesName, string modelsName)
        {
            this.ModulesName = modulesName;
            this.ModelsName = modelsName;
        }

        public class GetModelsForModulesDetailsHandler : IRequestHandler<GetModelsForModulesDetailsQuery, Response<GetModelsForModulesResponseDto>>
        {
            private readonly ILogger<GetModelsForModulesDetailsHandler> _logger;
            private readonly IModuleRepository _repository;
            public GetModelsForModulesDetailsHandler(ILogger<GetModelsForModulesDetailsHandler> logger, IModuleRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<GetModelsForModulesResponseDto>> Handle(GetModelsForModulesDetailsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetModelsForModulesDetailsAsync(request.ModulesName, request.ModelsName);
                return returnValue.ToResponse();
            }
        }
    }
}