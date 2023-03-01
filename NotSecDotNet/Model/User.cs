using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotSecDotNet.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Sex { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? EmailAddress { get; set; }

        public string? Motto { get; set; }

        public string? WebPageUrl { get; set; }
    }
}
