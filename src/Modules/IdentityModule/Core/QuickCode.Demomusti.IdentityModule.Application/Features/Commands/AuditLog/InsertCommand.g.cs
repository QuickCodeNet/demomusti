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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.AuditLog;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.AuditLog
{
    public class InsertAuditLogCommand : IRequest<Response<AuditLogDto>>
    {
        public AuditLogDto request { get; set; }

        public InsertAuditLogCommand(AuditLogDto request)
        {
            this.request = request;
        }

        public class InsertAuditLogHandler : IRequestHandler<InsertAuditLogCommand, Response<AuditLogDto>>
        {
            private readonly ILogger<InsertAuditLogHandler> _logger;
            private readonly IAuditLogRepository _repository;
            public InsertAuditLogHandler(ILogger<InsertAuditLogHandler> logger, IAuditLogRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<AuditLogDto>> Handle(InsertAuditLogCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.InsertAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}