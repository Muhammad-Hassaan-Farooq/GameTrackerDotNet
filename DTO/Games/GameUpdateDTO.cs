using System.ComponentModel.DataAnnotations;

namespace api.Games.DTO
{
    public class GameUpdateDTO
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
    }
}