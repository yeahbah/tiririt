using System;

namespace Tiririt.Domain.Models
{
    public class UserModel 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UserName { get; set; }
    }
}