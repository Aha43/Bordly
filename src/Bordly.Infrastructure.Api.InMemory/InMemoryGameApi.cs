using Bordly.Specification.Api;
using Bordly.Specification.Domain;
using Bordly.Specification.Domain.Param;

namespace Bordly.Infrastructure.Api.InMemory;

public class InMemoryGameApi : IGameApi
{
    public Task<IGameModel> CreateGameAsync(ICreateGameParam param, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IGameRowModel>> GetGameAsync(IGameParam param, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IGameModel>> GetGamesAsync(IGamesParam param, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IGameRowModel> PlayAsync(IMoveParam param, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
