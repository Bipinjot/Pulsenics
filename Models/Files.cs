using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Pulsenics.Models;

public class FileSystem
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    public string? Extension { get; set; }
    [DataType(DataType.Date)]
    public DateTime CreatedDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime LastModifiedDate { get; set; }
}