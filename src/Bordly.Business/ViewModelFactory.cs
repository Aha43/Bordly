using Bordly.Business.Exceptions;
using Bordly.Business.ViewModel;
using Bordly.Domain.Param;
using Bordly.Specification.Api;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

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

        public PlayerViewModel GetLoggedInPlayerOrFail() 
        {
            if (PlayerLoggedIn(out PlayerViewModel? player)) 
            {
                return player;
            }

            throw new NoUserLoggedOnException();
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
            var player = GetLoggedInPlayerOrFail();
            
            var param = new GamesParam { UsersEmailAddress = player.Email };
            var games = await _gameApi.GetGamesAsync(param, cancellationToken);
            var retVal = games.Select(e => new GameViewModel(e));
            return retVal;
        }

        public async Task<GameViewModel> CreateGameAsync(string name, CancellationToken cancellationToken = default)
        {
            var player = GetLoggedInPlayerOrFail();
            
            var param = new CreateGameParam { Name = name, UserEmailAddress = player.Email };
            var game = await _gameApi.CreateGameAsync(param, cancellationToken);
            return new GameViewModel(game);
        }

        public async Task<GameViewModel> GetGameAsync(string gameId, CancellationToken cancellationToken = default)
        {
            var param = new GameParam { GameId = gameId };
            var game = await _gameApi.GetGameAsync(param, cancellationToken);
            return new GameViewModel(game);
        }

        public async Task<IEnumerable<GameRowViewModel>> GetGameRowsAsync(GameViewModel game, CancellationToken cancellationToken = default)
        {
            var player = GetLoggedInPlayerOrFail();

            var param = new GameParam { GameId = game.Id };
            var rows = await _gameApi.GetGameRowsAsync(param, cancellationToken);
            return rows.Select(e => new GameRowViewModel(e));
        }

        public async Task<GameRowViewModel> MakeMove(GameViewModel game, string word, CancellationToken cancellationToken = default)
        {
            var param = new MoveParam
            {
                GameId = game.Id,
                Letters = word
            };
            var row = await _gameApi.PlayAsync(param, cancellationToken);
            return new GameRowViewModel(row);
        }

    }

}
