
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Games")]
public class Game{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Platform { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string? CoverImageUrl { get; set; }

    
    public string? UserID { get; set; }
    public AppUser? User { get; set; }

    public List<Note>? Notes { get; set; }



}