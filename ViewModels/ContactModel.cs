using System.ComponentModel.DataAnnotations;

namespace DoAnBE.ViewModels
{
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public bool IsStatus { get; set; }

    }
}
