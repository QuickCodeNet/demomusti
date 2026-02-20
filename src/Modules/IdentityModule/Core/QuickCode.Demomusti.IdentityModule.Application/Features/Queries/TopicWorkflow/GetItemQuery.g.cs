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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.TopicWorkflow;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.TopicWorkflow
{
    public class GetItemTopicWorkflowQuery : IRequest<Response<TopicWorkflowDto>>
    {
        public int Id { get; set; }

        public GetItemTopicWorkflowQuery(int id)
        {
            this.Id = id;
        }

        public class GetItemTopicWorkflowHandler : IRequestHandler<GetItemTopicWorkflowQuery, Response<TopicWorkflowDto>>
        {
            private readonly ILogger<GetItemTopicWorkflowHandler> _logger;
            private readonly ITopicWorkflowRepository _repository;
            public GetItemTopicWorkflowHandler(ILogger<GetItemTopicWorkflowHandler> logger, ITopicWorkflowRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<TopicWorkflowDto>> Handle(GetItemTopicWorkflowQuery request, CancellationToken cancellationToken)
            {
                var returnValue = await _repository.GetByPkAsync(request.Id);
                return returnValue.ToResponse();
            }
        }
    }
}