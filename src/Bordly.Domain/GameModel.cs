using Bordly.Specification.Domain;

namespace Bordly.Domain
{
    public class GameModel : IGameModel
    {
        public required string Id { get; init; }
        public required string UserEmailAddress { get; init; }
        public required string Name { get; init; }
        public required int Attempts { get; init; }
    }
}
