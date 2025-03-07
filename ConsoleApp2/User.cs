namespace ConsoleApp2
{
    public class User
    {
        private static int _autoIncrementId = 1;
        public User(string username, string password, Role role)
        {
            Username = username;
            Password = password;
            Role = role;
            Id = _autoIncrementId++;
        }

        public int Id { get; }
        public string Username { get; }
        public string Password { get; }
        public Role Role { get; }
    }

    public enum Role
    {
        Admin,
        User

    }
}
