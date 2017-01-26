using System.ComponentModel.DataAnnotations;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class EmailConfiguration
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public bool EnableSsl { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}