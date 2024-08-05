using MediatR;

namespace Mabieati.Kernel.Messages
{
    public record UserLoggedInMessage() : INotification;
}
