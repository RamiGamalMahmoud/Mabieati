using Mabieati.Kernel.Messages;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mabieati.Features.Dashboard.Home
{
    public static class ShowDashboard
    {
        internal class Handler : INotificationHandler<UserLoggedInMessage>
        {
            private readonly IServiceProvider _serviceProvider;

            public Handler(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }
            public async Task Handle(UserLoggedInMessage notification, CancellationToken cancellationToken)
            {
                _serviceProvider.GetRequiredService<IDashboardView>().Show();
                await Task.CompletedTask;
            }
        }
    }
}
