using Bordly.Specification.Domain;

namespace Bordly.Domain
{
    public class GameRowModel : IGameRowModel
    {
        public required string Statuses { get; init; }
    }
}
