using Bordly.Specification.Domain;

namespace Bordly.Business.ViewModel
{
    public class GameRowViewModel
    {
        private readonly IGameRowModel _model;

        public GameRowViewModel(IGameRowModel model) => _model = model;

        public string Letters => _model.Letters;
        public string Status => _model.Letters;
    }
}
