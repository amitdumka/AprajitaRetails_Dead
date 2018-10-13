namespace AprajitaRetails
{
    internal class AuthUsers
    {
        private int role;
        private string password;
        private int iD;
        private string userName;

        public int ID { get => iD; set => iD = value; }
        public int Role { get => role; set => role = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}