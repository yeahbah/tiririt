using Tiririt.Data.Entities;

namespace Tiririt.Web.Models
{
    public class RegisterResponseViewModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public RegisterResponseViewModel(TIRIRIT_USER user)
        {
            Id = user.Id;
            Name = user.FIRST_NAME;
            Email = user.Email;
        }        
    }
}
