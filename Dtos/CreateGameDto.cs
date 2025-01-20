using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

// id no va aqui porque lo proporcionara el servidor
public record class CreateGameDto(
   [Required] [StringLength(50)] string Name,
    [Required] [StringLength(30)]string Genre,
    [Range(1, 200)] decimal Price,
    string Description,
    DateOnly ReleaseDate
);
