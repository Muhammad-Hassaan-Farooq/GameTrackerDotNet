using System.Security.Claims;
using api.Games.DTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/games")]
[ApiController]
[Authorize]
public class GamesController:ControllerBase{
    private readonly IGameRepository _gameRepository;
    private readonly UserManager<AppUser> _userManager;
    public GamesController(IGameRepository gameRepository,UserManager<AppUser> userManager)
    {
        _gameRepository = gameRepository;
        _userManager = userManager;
    }
   

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetGames(GetGamesRequest getGamesRequest){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        if(userEmail == null){
            return Unauthorized();
        }
        var user = await _userManager.FindByEmailAsync(userEmail);
        if(user == null){
            return Unauthorized();
        }
        try
        {
            var gamequery = GameMapper.GameRequestToGameQuery(getGamesRequest,user);
            var games = await _gameRepository.GetAllGamesAsync(gamequery);
            var response = games.Select(g => GameMapper.GameToGameResponseDTO(g)).ToList();
        
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(int id){
        var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        if(userEmail == null){
            return Unauthorized();
        }
        var user = await _userManager.FindByEmailAsync(userEmail);
        if(user == null){
            return Unauthorized();
        }

        try
        {
            var game = await _gameRepository.GetGameAsync(id,user);
            if(game == null){
                return NotFound();
            }
            return Ok(game);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

       
    }
    [HttpPut("{id}")]
    public IActionResult UpdateGame(int id,[FromBody] GameUpdateDTO gameUpdateDTO){
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        return Ok("Game "+id+" Updated");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id){
         var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        if(userEmail == null){
            return Unauthorized();
        }
        var user = await _userManager.FindByEmailAsync(userEmail);
        if(user == null){
            return Unauthorized();
        }
        try
        {
            var game = await _gameRepository.GetGameAsync(id,user);
            if(game == null){
                return NotFound("Game doesnot exist");
            }
            await _gameRepository.DeleteGameAsync(game.Id);
            return Ok("Game "+id+" Deleted");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] NewGameDTO newGameDTO){
         var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
        if(userEmail == null){
            return Unauthorized();
        }
        var user = await _userManager.FindByEmailAsync(userEmail);
        if(user == null){
            return Unauthorized();
        }
        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }
        if(newGameDTO.ReleaseDate.CompareTo(new DateTime(1970, 1, 1, 0, 0, 0)) < 0){
            return BadRequest("Release Date is required");
        }
        try
        {
            var game = GameMapper.NewGameDTOToGame(newGameDTO,user);
        await _gameRepository.CreateGameAsync(game);
            return Ok("Game Created");
            
        }
        catch (System.Exception)
        {
            
           return StatusCode(500,"Error Creating Game");
        }
        
        
    }
}
