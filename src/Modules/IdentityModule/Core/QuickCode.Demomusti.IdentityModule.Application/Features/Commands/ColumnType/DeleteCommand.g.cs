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
using QuickCode.Demomusti.IdentityModule.Application.Dtos.ColumnType;
using QuickCode.Demomusti.IdentityModule.Domain.Enums;

namespace QuickCode.Demomusti.IdentityModule.Application.Features.ColumnType
{
    public class DeleteColumnTypeCommand : IRequest<Response<bool>>
    {
        public ColumnTypeDto request { get; set; }

        public DeleteColumnTypeCommand(ColumnTypeDto request)
        {
            this.request = request;
        }

        public class DeleteColumnTypeHandler : IRequestHandler<DeleteColumnTypeCommand, Response<bool>>
        {
            private readonly ILogger<DeleteColumnTypeHandler> _logger;
            private readonly IColumnTypeRepository _repository;
            public DeleteColumnTypeHandler(ILogger<DeleteColumnTypeHandler> logger, IColumnTypeRepository repository)
            {
                _logger = logger;
                _repository = repository;
            }

            public async Task<Response<bool>> Handle(DeleteColumnTypeCommand request, CancellationToken cancellationToken)
            {
                var model = request.request;
                var returnValue = await _repository.DeleteAsync(model);
                return returnValue.ToResponse();
            }
        }
    }
}