using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Mabieati.Data;
using Mabieati.Kernel.Messages;
using Mabieati.Kernel.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mabieati.Features.Auth.Login
{
    internal partial class ViewModel : ObservableValidator
    {
        public ViewModel(AppDbContextFactory contextFactory, IMediator mediator, IMessenger messenger)
        {
            _contextFactory = contextFactory;
            _mediator = mediator;
            _messenger = messenger;
            ValidateAllProperties();
#if DEBUG
            UserName = Password = "admin";
#endif
        }

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task Login()
        {
            using (AppDbContext context = _contextFactory.CreateDbContext())
            {
                User user = await context
                    .Users
                    .Where(u => u.UserName == UserName && EF.Property<string>(u, nameof(Password)) == Password)
                    .FirstOrDefaultAsync();

                if(user is not null)
                {
                    _messenger.Send<UserLoggedInMessage>();
                    await _mediator.Publish(new UserLoggedInMessage());
                    Message = "";
                }
                else
                {
                    Message = "User is not existed or wrong password";
                }
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !HasErrors;
        }

        public bool HasMessage => !string.IsNullOrEmpty(Message);

        [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMessage))]
        private string _message;

        [ObservableProperty]
        [Required(ErrorMessage = "User Name is required")]
        [MinLength(5, ErrorMessage = "Min length is 5")]
        [NotifyDataErrorInfo]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _userName;
        
        [ObservableProperty]
        [Required(ErrorMessage = "Password is required")]
        [NotifyDataErrorInfo]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _password;
        
        private readonly AppDbContextFactory _contextFactory;
        private readonly IMediator _mediator;
        private readonly IMessenger _messenger;
    }
}
