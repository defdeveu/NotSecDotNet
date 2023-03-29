using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NotSecDotNet.Dto
{
    public class OrderItemDto
    {

        [Required]
        public int MovieObjectId { get; set; }

       
        [Range(0, 100_000)]
        [Required]
        public int NrOfItemsOrdered { get; set; }
    }
}
