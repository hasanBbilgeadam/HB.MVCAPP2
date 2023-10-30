namespace HB.MVCAPP2.Models
{
    public class AppUser
    {

        public AppUser()
        {
            Token = new Random().Next(1000, 10000);

        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public string SurName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int Token { get; set; }    

    }
}
