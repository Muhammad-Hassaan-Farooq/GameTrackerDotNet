namespace api.Games.DTO
{
    public class GameResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
    }
}