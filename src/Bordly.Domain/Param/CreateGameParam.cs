using Bordly.Specification.Domain.Param;

namespace Bordly.Domain.Param
{
    public class CreateGameParam : ICreateGameParam
    {
        public required string UserEmailAddress { get; init; }
    }
}
