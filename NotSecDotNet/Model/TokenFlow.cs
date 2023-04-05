using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotSecDotNet.Model
{
    public class TokenFlow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FromAccountId { get; set; }
        
        public TokenAccount FromAccount { get; set; }

        public int ToAccountId { get; set; }
        public TokenAccount ToAccount { get; set; }

        public int Amount { get; set; }

    }
}
