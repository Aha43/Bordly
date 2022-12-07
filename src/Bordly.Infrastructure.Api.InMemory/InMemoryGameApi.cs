using Bordly.Domain;
using Bordly.Specification.Api;
using Bordly.Specification.Domain;
using Bordly.Specification.Domain.Param;
using System.Text;

namespace Bordly.Infrastructure.Api.InMemory;

public class InMemoryGameApi : IGameApi
{
    private readonly Dictionary<string, Game> _games = new();

    public Task<IGameModel> CreateGameAsync(ICreateGameParam param, CancellationToken cancellationToken = default)
    {
        var retVal = new GameModel
        {
            Id = Guid.NewGuid().ToString(),
            UserEmailAddress = param.UserEmailAddress,
            Name = param.Name,
            Attempts = 9
        };

        _games[retVal.Id] = new Game 
        { 
            GameModel = retVal,
            Word = "danse"
        };

        return Task.FromResult(retVal as IGameModel);
    }

    public Task<IGameModel> GetGameAsync(IGameParam param, CancellationToken cancellationToken = default) 
    {
        if (_games.TryGetValue(param.GameId, out Game? game))
        {
            return Task.FromResult(game.GameModel);
        }

        throw new ArgumentException($"no game with id '{param.GameId}'");
    }

    public Task<IEnumerable<IGameRowModel>> GetGameRowsAsync(IGameParam param, CancellationToken cancellationToken = default)
    {
        if (_games.TryGetValue(param.GameId, out Game? game))
        {
            var retVal = game.RowModels.AsEnumerable();
            return Task.FromResult(retVal);
        }

        throw new ArgumentException($"no game with id '{param.GameId}'");
    }

    public Task<IEnumerable<IGameModel>> GetGamesAsync(IGamesParam param, CancellationToken cancellationToken = default)
    {
        var retVal = _games.Values.Where(e => e.GameModel.UserEmailAddress == param.UsersEmailAddress).Select(e => e.GameModel);
        return Task.FromResult(retVal);
    }

    public Task<IGameRowModel> PlayAsync(IMoveParam param, CancellationToken cancellationToken = default)
    {
        if (_games.TryGetValue(param.GameId, out Game? game))
        {
            if (param.Letters.Length != game.Word.Length)
            {
                throw new ArgumentException($"played word of incorrect length '{param.Letters.Length}' : length must be '{game.Word.Length}'");
            }

            var sb = new StringBuilder();
            for (var i = 0; i < game.Word.Length; i++)
            {
                if (char.ToLower(param.Letters[i]) == game.Word[i])
                {
                    sb.Append('c');
                }
                else if (game.Word.Contains(param.Letters[i]))
                {
                    sb.Append('w');
                }
                else
                {
                    sb.Append('x');
                }
            }

            var retVal = new GameRowModel { Statuses= sb.ToString(), Letters = param.Letters };
            game.RowModels.Add(retVal);
            return Task.FromResult(retVal as IGameRowModel);
        }

        throw new ArgumentException($"no game with id '{param.GameId}'");
    }

}

internal class Game
{
    internal required string Word { get; init; }
    internal required IGameModel GameModel { get; init; }
    internal readonly List<IGameRowModel> RowModels = new();
}
