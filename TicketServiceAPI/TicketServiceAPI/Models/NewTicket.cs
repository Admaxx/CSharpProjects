using System.ComponentModel.DataAnnotations;

namespace TicketServiceAPI.Models
{
    public class NewTicket
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        [MinLength(5)]
        public string Description { get; set; }
    }
}
