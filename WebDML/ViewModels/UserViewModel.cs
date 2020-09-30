using System;

namespace WebDAL.ViewModels
{
    public class UserViewModel
    {

        public string UserId { get; set; }

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public int Rate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
