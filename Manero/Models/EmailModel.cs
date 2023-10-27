using System.ComponentModel.DataAnnotations;

namespace Manero.Models
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string ToEmail { get; set; }
    }
}
