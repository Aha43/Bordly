namespace Bordly.Business.ViewModel
{
    public class Game
    {
        public PlayerViewModel Player { get; }

        public int Moves { get; }

        public IReadOnlyList<GameMoveViewModel> Movements { get; }

        public Game(PlayerViewModel player, int moves, IEnumerable<GameMoveViewModel>? movements = null) 
        { 
            if (moves < 3)
            {
                throw new ArgumentException($"moves < 3 : {moves}");
            }

            Player = player;
            Moves = moves;
            Movements = movements == null ? Array.Empty<GameMoveViewModel>() : movements.ToList();
        }

    }

}
