
using Microsoft.AspNetCore.Identity;

public class AppUser:IdentityUser{
    public List<Game>? Games { get; set; }
    public List<Note>? Notes { get; set; }
}