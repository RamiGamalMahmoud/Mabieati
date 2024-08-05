using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mabieati.Features.Settings.Home
{
    public static class ShowHomeView
    {
        public record Command() : IRequest;
        internal class Handler : IRequestHandler<Command>
        {
            public Task Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
