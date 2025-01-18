using GameStore.Api.Data;
using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPointName = "GetGame";

 var games = GameData.Games;  //Data
// 1- Declarar nuestra lista

// "games" <-- name path , games <-- lista de juegos
//GET /games
app.MapGet(
    "games",
    () =>
    {
        if (games.Count == 0)
            return Results.NotFound("No games found.");

        return Results.Ok(games);
    }
);

// Recuperar los juegos GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id))
    .WithName(GetGameEndPointName);

//
// POST /games
//Se espera recibir un objeto CreateDto
app.MapPost(
    "games",
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
app.MapPut(
    "/games/{id}",
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

app.MapDelete(
    "games/{id}",
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

app.Run();
