using Microsoft.AspNetCore.Mvc;

[Route("api/notes")]
[ApiController]
public class NotesController:ControllerBase{

    public NotesController()
    {
        
    }

    [HttpGet("game/{id}")]
    public IActionResult GetNotes(int id){
        return Ok("Notes from Game "+id);
    }
    [HttpPost("game/{id}")]
    public IActionResult CreateNoteFromGame(int id){
        return Ok("Note Created from Game "+id);
    }

    [HttpGet("{id}")]
    public IActionResult GetNote(int id){
        return Ok("Notes "+id);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNote(int id){
        return Ok("Note "+id+" Deleted");
    }


}