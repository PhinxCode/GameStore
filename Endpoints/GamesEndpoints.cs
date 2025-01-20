using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    private static readonly List<GameDto> games =
    [
        new GameDto(
            1,
            "The Witcher 3: Wild Hunt",
            "RPG",
            59.99m,
            "A story-driven, open-world RPG set in a medieval fantasy world.",
            new DateOnly(2015, 5, 19)
        ),
        new GameDto(
            2,
            "God of War",
            "Action-Adventure",
            49.99m,
            "A journey through Norse mythology, following Kratos and his son Atreus.",
            new DateOnly(2018, 4, 20)
        ),
        new GameDto(
            3,
            "Minecraft",
            "Sandbox",
            29.99m,
            "A sandbox game where you can create and explore worlds made of blocks.",
            new DateOnly(2011, 11, 18)
        ),
        new GameDto(
            4,
            "Fortnite",
            "Battle Royale",
            0.00m,
            "A battle royale game where 100 players fight to be the last one standing.",
            new DateOnly(2017, 7, 25)
        ),
        new GameDto(
            5,
            "Red Dead Redemption 2",
            "Action-Adventure",
            59.99m,
            "An open-world western action-adventure game set in the dying days of the Wild West.",
            new DateOnly(2018, 10, 26)
        ),
        new GameDto(
            6,
            "Overwatch",
            "First-Person Shooter",
            39.99m,
            "A team-based first-person shooter with a diverse cast of characters.",
            new DateOnly(2016, 5, 24)
        ),
        new GameDto(
            7,
            "Horizon Zero Dawn",
            "Action RPG",
            39.99m,
            "An action RPG set in a post-apocalyptic world, featuring robotic creatures.",
            new DateOnly(2017, 2, 28)
        ),
        new GameDto(
            8,
            "The Elder Scrolls V: Skyrim",
            "RPG",
            39.99m,
            "An open-world RPG where you explore the fantasy world of Skyrim and fight dragons.",
            new DateOnly(2011, 11, 11)
        ),
        new GameDto(
            9,
            "Apex Legends",
            "Battle Royale",
            0.00m,
            "A free-to-play battle royale game with unique characters and abilities.",
            new DateOnly(2019, 2, 4)
        ),
        new GameDto(
            10,
            "Cyberpunk 2077",
            "RPG",
            59.99m,
            "An open-world RPG set in the futuristic dystopian city of Night City.",
            new DateOnly(2020, 12, 10)
        ),
        new GameDto(
            11,
            "The Legend of Zelda: Breath of the Wild",
            "Action-Adventure",
            59.99m,
            "A revolutionary open-world adventure game in the Zelda franchise.",
            new DateOnly(2017, 3, 3)
        ),
        new GameDto(
            12,
            "Grand Theft Auto V",
            "Action-Adventure",
            29.99m,
            "An open-world action game set in a sprawling city of crime and adventure.",
            new DateOnly(2013, 9, 17)
        ),
        new GameDto(
            13,
            "Call of Duty: Modern Warfare",
            "First-Person Shooter",
            59.99m,
            "A reimagined version of the classic first-person shooter.",
            new DateOnly(2019, 10, 25)
        ),
        new GameDto(
            14,
            "Super Mario Odyssey",
            "Platformer",
            59.99m,
            "A 3D platformer featuring Mario as he explores new kingdoms and saves Princess Peach.",
            new DateOnly(2017, 10, 27)
        ),
        new GameDto(
            15,
            "Animal Crossing: New Horizons",
            "Life Simulation",
            59.99m,
            "A life simulation game where you build and customize your island with friends.",
            new DateOnly(2020, 3, 20)
        ),
    ];

    public static RouteGroupBuilder MapGamesEndPoints(this WebApplication app)
    {
        //agrupar game en totalidad para no repetir el endpoint
        var group = app.MapGroup("games");
        // 1- Declarar nuestra lista

        // "games" <-- name path , games <-- lista de juegos
        //GET /games
        group.MapGet(
            "/",
            () => games.Count == 0 ? Results.NotFound("No games found.") : Results.Ok(games)
        );

        // Recuperar los juegos GET /games/1
        group
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    var game = games.Find(game => game.Id == id);
                    return game is not null
                        ? Results.Ok(game)
                        : Results.NotFound("Games not found.");
                }
            )
            .WithName(GetGameEndPointName);

        //Se espera recibir un objeto CreateDto
        // POST /games
        group.MapPost(
            "/",
            (CreateGameDto newGame) =>
            {
                GameDto game = new(
                    games.Count + 1,
                    newGame.Name,
                    newGame.Genre,
                    newGame.Price,
                    newGame.Description,
                    newGame.ReleaseDate
                );

                games.Add(game);
                return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id });
            }
        );

        // PUT /games   //Actualizar
        group.MapPut(
            "/{id}",
            (int id, UpdateGameDto updateGameDto) =>
            {
                // Buscar el índice del juego con el id especificado
                var index = games.FindIndex(game => game.Id == id);

                // Si no se encuentra el juego, devolver un 404
                if (index == -1)
                    return Results.NotFound();

                // Si se encuentra, actualizar el juego en la lista
                games[index] = new GameDto(
                    id,
                    updateGameDto.Name,
                    updateGameDto.Genre,
                    updateGameDto.Price,
                    updateGameDto.Description,
                    updateGameDto.ReleaseDate
                );

                // Devolver una respuesta de éxito

                return Results.NoContent();
            }
        );

        // DELETE /games/1

        group.MapDelete(
            "/{id}",
            (int id) =>
            {
                var deleteCount = games.RemoveAll(game => game.Id == id);

                if (deleteCount > 0)
                {
                    return Results.Ok("Delete successfully");
                }
                else
                {
                    return Results.NotFound("Game not found");
                }
            }
        );

        return group;
    }
}
