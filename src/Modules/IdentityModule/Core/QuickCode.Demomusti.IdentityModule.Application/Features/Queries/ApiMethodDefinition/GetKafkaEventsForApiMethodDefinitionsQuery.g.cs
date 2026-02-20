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
    public class GetKafkaEventsForApiMethodDefinitionsQuery : IRequest<Response<List<GetKafkaEventsForApiMethodDefinitionsResponseDto>>>
    {
        public string ApiMethodDefinitionsKey { get; set; }

        public GetKafkaEventsForApiMethodDefinitionsQuery(string apiMethodDefinitionsKey)
        {
            this.ApiMethodDefinitionsKey = apiMethodDefinitionsKey;
        }

        public class GetKafkaEventsForApiMethodDefinitionsHandler : IRequestHandler<GetKafkaEventsForApiMethodDefinitionsQuery, Response<List<GetKafkaEventsForApiMethodDefinitionsResponseDto>>>
        {
            private readonly ILogger<GetKafkaEventsForApiMethodDefinitionsHandler> _logger;
            private readonly IApiMethodDefinitionRepository _repository;
            public GetKafkaEventsForApiMethodDefinitionsHandler(ILogger<GetKafkaEventsForApiMethodDefinitionsHandler> logger, IApiMethodDefinitionRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<List<GetKafkaEventsForApiMethodDefinitionsResponseDto>>> Handle(GetKafkaEventsForApiMethodDefinitionsQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetKafkaEventsForApiMethodDefinitionsAsync(request.ApiMethodDefinitionsKey);
                return returnValue.ToResponse();
            }
        }
    }
}