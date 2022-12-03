using Bordly.Domain.Param;
using Bordly.Infrastructure.Api.InMemory;
using Bordly.Specification.Api;
using Bordly.Specification.Domain;
using FluentAssertions;
using Xunit.Priority;

namespace Bordly.Infrastructure.Api.Test;

[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class ApiTest
{
    private static IGameApi Api = new InMemoryGameApi();

    [Fact, Priority(10)]
    public async void TestShouldBeCreated()
    {
        var param = new CreateGameParam { UserEmailAddress = "arne.halvorsen@gmail.com", Name= "TestGame" };
        var game = await Api.CreateGameAsync(param);

        game.Should().BeAssignableTo<IGameModel>().Which.Name.Should().Be("TestGame");
    }

    [Fact, Priority(20)]
    public async void CreatedGameShouldBeFound()
    {
        var param = new GamesParam { UsersEmailAddress = "arne.halvorsen@gmail.com" };
        var games = await Api.GetGamesAsync(param);

        games.Should().NotBeNull().And.HaveCount(1);

        var game = games.First();
        game.Should().BeAssignableTo<IGameModel>().Which.Name.Should().Be("TestGame");
    }

    [Fact, Priority(30)]
    public async void CreatedGameShouldHaveNoRows()
    {
        var param1 = new GamesParam { UsersEmailAddress = "arne.halvorsen@gmail.com" };
        var games = await Api.GetGamesAsync(param1);
        var game = games.First();

        var param2 = new GameParam { GameId = game.Id };
        var rows = await Api.GetGameAsync(param2);

        rows.Should().BeEmpty();
    }

    [Fact, Priority(40)]
    public async void PlayedMoveShouldBeAsExpected()
    {
        var param1 = new GamesParam { UsersEmailAddress = "arne.halvorsen@gmail.com" };
        var games = await Api.GetGamesAsync(param1);
        var game = games.First();

        var param2 = new MoveParam
        {
            GameId = game.Id,
            Letters = "Baren"
        };
        var row = await Api.PlayAsync(param2);

        row.Should().BeAssignableTo<IGameRowModel>().Which.Statuses.Should().Be("xcxww");
    }

    [Fact, Priority(45)]
    public async void GameShouldBeAsExpectedAfterFirstMove()
    {
        var param1 = new GamesParam { UsersEmailAddress = "arne.halvorsen@gmail.com" };
        var games = await Api.GetGamesAsync(param1);
        var game = games.First();

        var param2 = new GameParam { GameId = game.Id };
        var rows = await Api.GetGameAsync(param2);

        rows.Should().HaveCount(1);
        
        var row = rows.First();
        row.Should().BeAssignableTo<IGameRowModel>().Which.Statuses.Should().Be("xcxww");
    }

    [Fact, Priority(50)]
    public async void GameShouldBeWonAsExcpected()
    {
        var param1 = new GamesParam { UsersEmailAddress = "arne.halvorsen@gmail.com" };
        var games = await Api.GetGamesAsync(param1);
        var game = games.First();

        var param2 = new MoveParam
        {
            GameId = game.Id,
            Letters = "dAnsE"
        };
        var row = await Api.PlayAsync(param2);

        row.Should().BeAssignableTo<IGameRowModel>().Which.Statuses.Should().Be("ccccc");
    }

    [Fact, Priority(55)]
    public async void GameShouldBeAsExpectedAfterIsWon()
    {
        var param1 = new GamesParam { UsersEmailAddress = "arne.halvorsen@gmail.com" };
        var games = await Api.GetGamesAsync(param1);
        var game = games.First();

        var param2 = new GameParam { GameId = game.Id };
        var rows = await Api.GetGameAsync(param2);

        rows.Should().HaveCount(2);

        var rowList = rows.ToList();
        rowList[0].Should().BeAssignableTo<IGameRowModel>().Which.Statuses.Should().Be("xcxww");
        rowList[1].Should().BeAssignableTo<IGameRowModel>().Which.Statuses.Should().Be("ccccc");
    }

}