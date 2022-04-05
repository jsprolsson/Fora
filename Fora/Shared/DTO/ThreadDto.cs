namespace Fora.Shared.DTO
{
    public class ThreadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime DateTimeModified { get; set; }

        public int InterestId { get; set; }
    }
}
