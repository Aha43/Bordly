using Bordly.Business.ViewModel;

namespace Bordly.Business.ViewController
{
    public class GamesViewController
    {
        private readonly ViewModelFactory _viewModelFactory;

        private List<GameViewModel> _games = new();
        public IEnumerable<GameViewModel> Game => _games.AsEnumerable();

        public GamesViewController(ViewModelFactory viewModelFactory) => _viewModelFactory = viewModelFactory;

        public async Task LoadAsync()
        {
            if (_viewModelFactory.Player != null)
            {
                _games = (await _viewModelFactory.GetGamesAsync()).ToList();
            }
        }

        public string? NewGameName { get; set; }

        public async Task CreateGameAsync() => await CreateGameAsync(default);

        public async Task CreateGameAsync(CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(NewGameName))
            {
                var newGame = await _viewModelFactory.CreateGameAsync(NewGameName, cancellationToken);
                _games.Add(newGame);
            }
        }

    }

}
