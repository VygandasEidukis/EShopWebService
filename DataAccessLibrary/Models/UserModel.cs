using DataAccessLibrary.Logic;

namespace DataAccessLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string IconPath { get; set; }

        public bool RegisterUser()
        {
            //Not null values
            if (FirstName == null || LastName == null || Password == null || Email == null || Username == null)
                return false;
            //account verification business logic
            if(FirstName.Length > 5 && FirstName.Length < 50 && LastName.Length > 5 && LastName.Length < 50)
            {
                if(Password.Length > 5 && Password.Length < 50 && Username.Length > 5 && Username.Length < 50)
                {
                    if(Email.Length > 5 && Email.Length < 100 && Email.Contains("@"))
                    {
                        if(UserProcessor.IsUsernameUnique(Username))
                        {
                            UserProcessor.CreateUser(this);
                            return true;
                        }
                    }
                }
            }
            return false;
        }



        public bool LogIn()
        {
            if(Username != null && Password != null)
            {
                if(Username.Length < 50 && Password.Length < 50)
                {
                    return UserProcessor.IsValidLogin(this);
                }
            }
            return false;
        }
    }
}
