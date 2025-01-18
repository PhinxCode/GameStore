using System;
using System.Collections.Generic;
using GameStore.Api.Dtos;

namespace GameStore.Api.Data
{
    public static class GameData
    {
        private static readonly List<GameDto> gameDtos = new List<GameDto>
        {
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
        };

        // Lista estática de juegos
        public static List<GameDto> Games { get; set; } = gameDtos;
    }
}
