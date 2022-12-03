namespace Bordly.Business.ViewModel
{
    public sealed class GameMoveViewModel
    {
        private readonly IReadOnlyList<GameMoveLetterViewModel> _letters;

        public int Length => _letters.Count;

        public GameMoveLetterViewModel this[int i] => _letters[i];

        public bool Won => !_letters.Any(e => e.Status != GameMoveLetterStatus.Correct);

        public GameMoveViewModel(GameMoveLetterViewModel[] letters) => _letters = (GameMoveLetterViewModel[])letters.Clone();
    }
}
