using Bordly.Business.ViewModel;

namespace Bordly.Business.ViewController
{
    public class GamesViewController
    {
        private readonly ViewModelFactory _viewModelFactory;

        public IReadOnlyCollection<GameViewModel> Games { get; private set; } = new List<GameViewModel>();

        public GamesViewController(ViewModelFactory viewModelFactory) => _viewModelFactory = viewModelFactory;

        public async Task LoadAsync()
        {
            if (_viewModelFactory.Player != null)
            {
                var games = await _viewModelFactory.GetGamesAsync();
                Games = games.ToList();
            }
        }
    }
}
