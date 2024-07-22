namespace api.Games.DTO
{
    public class GetGamesRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize{ get; set; } = 10;
    }
}