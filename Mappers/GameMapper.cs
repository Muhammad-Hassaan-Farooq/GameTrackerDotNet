using api.Games.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api.Mappers
{
    public static class GameMapper{
        public static GameQueryObject GameRequestToGameQuery(GetGamesRequest request,AppUser user){
            return new GameQueryObject{
                Page = request.Page,
                PageSize = request.PageSize,
                appUser = user

            };
        }

        public static Game NewGameDTOToGame(NewGameDTO newGameDTO,AppUser user){
            var date =  new DateTime(newGameDTO.ReleaseDate.Year,newGameDTO.ReleaseDate.Month,newGameDTO.ReleaseDate.Day);
            return new Game{
                Name = newGameDTO.Name,
                Platform = newGameDTO.Platform,
                ReleaseDate = date,
                CoverImageUrl = newGameDTO.CoverImageUrl,
                UserID = user.Id,
                User =user
            };

    }
        public static GameResponseDTO GameToGameResponseDTO(Game game){
            return new GameResponseDTO{
                Id = game.Id,
                Name = game.Name,
                Platform = game.Platform,
                ReleaseDate = game.ReleaseDate,
                CoverImageUrl = game.CoverImageUrl
            };
        }
    }
}