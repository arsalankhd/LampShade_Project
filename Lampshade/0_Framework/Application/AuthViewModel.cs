namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {

        }

        public AuthViewModel(long id, string fullname, string username, long roleId, List<int> permissions)
        {
            Id = id;
            Fullname = fullname;
            Username = username;
            RoleId = roleId;
            Permissions = permissions;
        }
    }
}