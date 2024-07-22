

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Notes")]
public class Note{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    
    public int GameId { get; set; }
    public Game? Game { get; set; }

    
    public string? UserId { get; set; }
    public AppUser? User { get; set; }
}