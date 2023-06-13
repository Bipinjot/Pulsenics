using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pulsenics.Models;

public class User
{
    public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid phone number.")]
        public string? Phone { get; set; }
        [ForeignKey("FileSystem")]
        [Display(Name = "File Id")]
        [Required]
        public int FileId { get; set; }
        public FileSystem File { get; set; }

}