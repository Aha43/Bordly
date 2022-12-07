using Bordly.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bordly.Business.ViewController
{
    public class PlayerViewController
    {
        private readonly ViewModelFactory _viewModelFactory;

        public PlayerViewController(ViewModelFactory viewModelFactory) => _viewModelFactory = viewModelFactory;

        public string? Email { get; set; }
        public string? Name { get; set; }

        public string Message { get; private set; } = string.Empty;

        public bool PlayerLoggedIn => _viewModelFactory.Player != null;

        public async Task LoginAsync()
        {
            if (string.IsNullOrEmpty(Email))
            {
                Message = "Missing email!";
                return;
            }
            if (string.IsNullOrEmpty(Name))
            {
                Message = "Missing name";
                return;
            }

            _ = await _viewModelFactory.LoginAsync(Email, Name);
        }

        public async Task LogoutAsync() => await _viewModelFactory.LogoutAsync();

    }

}
