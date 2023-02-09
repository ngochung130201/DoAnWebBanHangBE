using System.ComponentModel.DataAnnotations;

namespace DoAnBE.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public bool IsStatus { get; set; }

    }
}
