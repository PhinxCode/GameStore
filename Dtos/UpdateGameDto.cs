namespace GameStore.Api.Dtos;

public record class UpdateGameDto(
    string Name,
    string Genre,
    decimal Price,
    string Description,
    DateOnly ReleaseDate
);
