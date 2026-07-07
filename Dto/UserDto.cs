namespace WebApplication1.Dto
{
    public class UserDto
    {

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

    }
}
