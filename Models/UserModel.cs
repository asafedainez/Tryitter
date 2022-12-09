namespace Tryitter.Models
{
    public class UserModel
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; init; }

        public ModulesTypes Module { get; set; }
        public string? Status { get; set; }
    }
}
