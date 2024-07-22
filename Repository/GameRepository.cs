using api.Games.DTO;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDBContext _context;

        public GameRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Game>> GetAllGamesAsync(GameQueryObject gameQueryObject)
        {

            var games = await _context.Games
                .Where(g => g.UserID == gameQueryObject.appUser.Id)
                .Skip((gameQueryObject.Page - 1) * gameQueryObject.PageSize)
                .Take(gameQueryObject.PageSize)
                .ToListAsync();
            return games;
        }
        public async Task<Game?> GetGameAsync(int id,AppUser appUser)
        {
           var game = await _context.Games
                .Where(g => g.UserID == appUser.Id && g.Id == id)
                .FirstOrDefaultAsync();
            return game;
        }
        public async Task<Game> CreateGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games
                .Where(g => g.Id == id)
                .FirstOrDefaultAsync();
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }
}