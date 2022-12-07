using Bordly.Specification.Domain;
using Bordly.Specification.Domain.Param;

namespace Bordly.Specification.Api
{
    public interface IGameApi
    {
        Task<IEnumerable<IGameModel>> GetGamesAsync(IGamesParam param, CancellationToken cancellationToken = default);
        Task<IGameModel> GetGameAsync(IGameParam param, CancellationToken cancellationToken = default);
        Task<IGameModel> CreateGameAsync(ICreateGameParam param, CancellationToken cancellationToken = default);
        Task<IEnumerable<IGameRowModel>> GetGameRowsAsync(IGameParam param, CancellationToken cancellationToken = default);
        Task<IGameRowModel> PlayAsync(IMoveParam param, CancellationToken cancellationToken = default);
    }
}
