



using api.Games.DTO;

namespace api.Interfaces{
    public interface IGameRepository{
        Task<List<Game>> GetAllGamesAsync(GameQueryObject gameQueryObject);
        Task<Game> GetGameAsync(int id,AppUser appUser);
        Task<Game> CreateGameAsync(Game game);

        Task DeleteGameAsync(int id);

    }
}