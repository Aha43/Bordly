using Bordly.Business.Exceptions;
using Bordly.Business.ViewModel;
using Bordly.Domain.Param;
using Bordly.Specification.Api;
using System.Diagnostics.CodeAnalysis;

namespace Bordly.Business
{
    public class ViewModelFactory
    {
        private readonly IGameApi _gameApi;

        private PlayerViewModel? _player = null;

        public ViewModelFactory(IGameApi gameApi) => _gameApi = gameApi;

        public bool PlayerLoggedIn() => _player != null;

        public bool PlayerLoggedIn([NotNullWhen(returnValue: true)] out PlayerViewModel? player)
        {
            player = _player;
            return _player != null;
        }

        public Task<PlayerViewModel> LoginAsync(string email, string name, CancellationToken cancellationToken = default)
        {
            _player = new PlayerViewModel { Email = email, Name = name };
            return Task.FromResult(_player);
        }

        public Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            _player = null;
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<GameViewModel>> GetGamesAsync(CancellationToken cancellationToken = default)
        {
            if (PlayerLoggedIn(out PlayerViewModel? player))
            {
                var param = new GamesParam { UsersEmailAddress = player.Email };

                var games = await _gameApi.GetGamesAsync(param, cancellationToken);
                var retVal = games.Select(e => new GameViewModel(e));
                return retVal;
            }

            throw new NoUserLoggedOnException();
        }

        public async Task<GameViewModel> CreateGameAsync(string name, CancellationToken cancellationToken = default)
        {
            if (PlayerLoggedIn(out PlayerViewModel? player))
            {
                var param = new CreateGameParam { Name = name, UserEmailAddress = player.Email };
                var game = await _gameApi.CreateGameAsync(param, cancellationToken);
                return new GameViewModel(game);
            }

            throw new NoUserLoggedOnException();
        }

    }

}
