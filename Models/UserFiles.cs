using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pulsenics.Models;

public class UserFiles
{
    public int Id { get; set; }

        [Required]
        [ForeignKey("FileSystem")]
        [Display(Name = "File Id")]
        [Index("IX_FirstAndSecond", IsUnique = true)]
        public int FileId { get; set; }
        public FileSystem File { get; set; }

        [Required]
        [ForeignKey("User")]
        [Display(Name = "User Id")]
        [Index("IX_FirstAndSecond", IsUnique = true)]
        public int UserId { get; set; }
        public User User { get; set; }

}
