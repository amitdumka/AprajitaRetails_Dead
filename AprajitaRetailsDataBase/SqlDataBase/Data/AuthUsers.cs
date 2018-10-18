namespace AprajitaRetailsDataBase.SqlDataBase
{
    /// <summary>
    /// It store Username and password with it role
    ///
    /// </summary>
    public class AuthUsers
    {
        public int ID { get; set; }
        public int Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}