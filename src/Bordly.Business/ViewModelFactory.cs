using Bordly.Business.Exceptions;
using Bordly.Business.ViewModel;
using Bordly.Domain.Param;
using Bordly.Specification.Api;

namespace Bordly.Business
{
    public class ViewModelFactory
    {
        private readonly IGameApi _gameApi;

        public PlayerViewModel? Player { get; private set; } = null;

        public ViewModelFactory(IGameApi gameApi)
        {
            _gameApi = gameApi;
        }

        public Task<PlayerViewModel> LoginAsync(string email, string name, CancellationToken cancellationToken = default)
        {
            Player = new PlayerViewModel { Email = email, Name = name };
            return Task.FromResult(Player);
        }

        public Task LogoutAsync(CancellationToken cancellationToken = default)
        {
            Player = null;
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<GameViewModel>> GetGamesAsync(CancellationToken cancellationToken = default)
        {
            if (Player != null)
            {
                var param = new GamesParam { UsersEmailAddress = Player.Email };

                var games = await _gameApi.GetGamesAsync(param, cancellationToken);
                var retVal = games.Select(e => new GameViewModel(e));
                return retVal;
            }

            throw new NoUserLoggedOnException();
        }

    }

}
