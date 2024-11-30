namespace Hospital_Managment_System.Models
{
    public class User
    {

        public string UserName { get; set; } 

        public string Password { get; set; }

        public string Email { get; set; }

        List<Role> Roles { get; set; }
    }
}
