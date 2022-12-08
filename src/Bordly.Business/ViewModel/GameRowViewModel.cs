using Bordly.Specification.Domain;

namespace Bordly.Business.ViewModel
{
    public class GameRowViewModel
    {
        private readonly IGameRowModel _model;

        public IEnumerable<GameRowLetterViewModel> GameRows { get; private set; }

        public GameRowViewModel(IGameRowModel model)
        {
            _model = model;
            GameRows = _model.Letters.Select((e, i) => new GameRowLetterViewModel { Letter = e, Status = model.Statuses[i] });
        }
       
    }

}
