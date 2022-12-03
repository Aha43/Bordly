using Bordly.Specification.Domain;
using Bordly.Specification.Domain.Param;

namespace Bordly.Specification.Api
{
    public interface IGameApi
    {
        Task<IEnumerable<IGameModel>> GetGamesAsync(IGamesParam param, CancellationToken cancellationToken = default);
        Task<IEnumerable<IGameRow>> GetGameAsync(IGameParam param, CancellationToken cancellationToken = default);
        Task<IGameRow> PlayAsync(IMoveParam param, CancellationToken cancellationToken = default);
    }
}
