using Microsoft.AspNetCore.Identity;

namespace cse355.Models
{
    public class AppUserCustomer : IdentityUser
    {
        public Order? Order { get; set; }

        public string username { get; set; }
        
        public string password { get; set; }

        public Order? Order { get; set; }


    }
}
