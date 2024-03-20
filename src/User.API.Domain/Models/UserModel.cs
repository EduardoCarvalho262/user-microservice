namespace User.API.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
