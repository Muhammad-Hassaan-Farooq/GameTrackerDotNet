using System.ComponentModel.DataAnnotations;

namespace api.Games.DTO
{
    public class NewGameDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Platform { get; set; }
        
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string CoverImageUrl { get; set; }
    }
}