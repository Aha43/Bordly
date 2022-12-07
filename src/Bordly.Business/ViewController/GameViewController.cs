using Bordly.Business.ViewModel;

namespace Bordly.Business.ViewController
{
    public class GameViewController
    {
        private readonly ViewModelFactory _viewModelFactory;

        public GameViewModel? Game { get; private set; }

        private List<GameRowViewModel> _rows = new();
        public IEnumerable<GameRowViewModel> Rows => _rows.AsEnumerable();

        public GameViewController(ViewModelFactory viewModelFactory) => _viewModelFactory = viewModelFactory;

        public async Task LoadAsync(string gameId, CancellationToken cancellationToken = default)
        {
            if (_viewModelFactory.PlayerLoggedIn())
            {
                var game = await _viewModelFactory.GetGameAsync(gameId, cancellationToken);
                _rows = (await _viewModelFactory.GetGameRowsAsync(game, cancellationToken)).ToList();
                Game = game;
            }
        }

        public string? Move { get; set; }

        public async Task MakeMoveAsync() => await MakeMoveAsync(default);
        
        public async Task MakeMoveAsync(CancellationToken cancellationToken)
        {
            //if ()
        }

    }

}
