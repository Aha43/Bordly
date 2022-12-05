namespace Bordly.Business.ViewModelOld
{
    public sealed class GameMoveLetterViewModel
    {
        public char Letter { get; }

        public GameMoveLetterStatus Status { get; }

        public GameMoveLetterViewModel(char letter, GameMoveLetterStatus status)
        {
            Letter = letter;
            Status = status;
        }

    }

}
