using Bordly.Specification.Domain;

namespace Bordly.Domain
{
    public class GameRowModel : IGameRowModel
    {
        public required string Letters { get; init; }
        public required string Statuses { get; init; }
    }
}
