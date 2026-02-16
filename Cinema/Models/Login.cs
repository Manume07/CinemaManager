namespace Cinema.Models
{
    public class Login
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool CredenzialiCorrette()
        {
            if(Username == "admin" && Password == "1234")
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
    }
}
