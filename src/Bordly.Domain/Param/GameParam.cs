using Bordly.Specification.Domain.Param;

namespace Bordly.Domain.Param
{
    public class GameParam : IGameParam
    {
        public required string GameId { get; init; }
    }
}
