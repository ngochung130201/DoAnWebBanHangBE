using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Member
    {
        [Key]
        public Guid ID { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }
        public string Email { set; get; }
        public string Telephone { set; get; }
        public string About { set; get; }
        public bool Status { set; get; }
        public DateTime? Birthday { set; get; }
        public string Avatar { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
        public DateTime DateCreated { set; get; }
        public int Role { set; get; }
    }
}
