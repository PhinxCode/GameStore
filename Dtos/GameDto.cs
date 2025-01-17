namespace GameStore.Api.Dtos;

//declarar las propiedades
public record class GameDto(int Id, string Name, string Genre, decimal Price, string Description, DateOnly ReleaseDate);
