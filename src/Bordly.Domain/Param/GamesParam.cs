using Bordly.Specification.Domain.Param;

namespace Bordly.Domain.Param
{
    public class GamesParam : IGamesParam
    {
        public required string UsersEmailAddress { get; init; }
    }
}
