using Microsoft.Build.Framework;

namespace WebAppMvc.Models
{
    public class Product
    {
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }
    }
}
