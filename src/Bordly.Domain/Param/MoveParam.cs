using Bordly.Specification.Domain.Param;

namespace Bordly.Domain.Param
{
    public class MoveParam : IMoveParam
    {
        public required string GameId { get; init; }
        public required string Letters { get; init; }
    }
}
