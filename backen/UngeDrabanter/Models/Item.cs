using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class Item
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUri { get; set; }
        public string ItemUri { get; set; }

        public decimal Price { get; set; }

        public string CurrencyCode { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<ItemDetail> ItemDetails { get; set; }
    }
}
