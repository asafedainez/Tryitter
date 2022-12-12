namespace Tryitter.Models
{
    public class UserInput
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; init; }

        public ModulesTypes Module { get; set; }
        public string? Status { get; set; }

        public User ToInput()
        {
            var user = new User()
            {
                Name = Name,
                Password = Password,
                Email = Email,
                Module = Module,
                Status = Status,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            };
            return user;
        }
    }
}
