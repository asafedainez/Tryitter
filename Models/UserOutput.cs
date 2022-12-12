namespace Tryitter.Models
{
    public class UserOutput
    {
        public UserOutput(int id, string? name, string? email, ModulesTypes module, string? status)
        {
            Id = id;
            Name = name;
            Email = email;
            Module = module;
            Status = status;
        }

        public UserOutput(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Module = user.Module;
            Status = user.Status;
        }

        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; init; }

        public ModulesTypes Module { get; set; }
        public string? Status { get; set; }
    }
}
