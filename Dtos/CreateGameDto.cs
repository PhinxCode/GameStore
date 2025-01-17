namespace GameStore.Api.Dtos;

// id no va aqui porque lo proporcionara el servidor
public record class CreateGameDto(
    string Name,
    string Genre,
    decimal Price,
    string Description,
    DateOnly ReleaseDate
);
