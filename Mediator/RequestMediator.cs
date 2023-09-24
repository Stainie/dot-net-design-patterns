using JetBrains.Annotations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class RequestCommand : IRequest<ResponseCommand>
    {
    }

    public class ResponseCommand
    {
        public string Response { get; set; }

        public ResponseCommand(string response)
        {
            Response = response;
        }
    }

    [UsedImplicitly]
    public class RequestHandler : IRequestHandler<RequestCommand, ResponseCommand>
    {
        public async Task<ResponseCommand> Handle(RequestCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new ResponseCommand("Response from RequestHandler")).ConfigureAwait(false);
        }
    }
}
