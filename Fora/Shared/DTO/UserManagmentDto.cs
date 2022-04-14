namespace Fora.Shared.DTO
{
    public class UserManagmentDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public bool Admin { get; set; }
        public bool Banned { get; set; }
    }
}
