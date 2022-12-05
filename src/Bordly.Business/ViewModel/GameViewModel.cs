using Bordly.Specification.Domain;

namespace Bordly.Business.ViewModel
{
    public class GameViewModel
    {
        private readonly IGameModel _model;

        public GameViewModel(IGameModel model) => _model = model;

        public string Name => _model.Name;

        public string Id => _model.Id;

    }

}
