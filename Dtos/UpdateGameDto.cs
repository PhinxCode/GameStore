using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGameDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(30)] string Genre,
    [Range(1, 200)] decimal Price,
    [StringLength(150)] string Description,
    DateOnly ReleaseDate
);
