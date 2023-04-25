using System.ComponentModel.DataAnnotations;

namespace UngeDrabanter.Models
{
    public class Event
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public Guid UserHostId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? EventUri { get; set; }

        public string? ImageUri { get; set; }

        [Required]
        public string EventCode { get; set; }

        public DateTime? EventDateTime { get; set; }

        //public IEnumerable<EventUser> EventUsers { get; set; }

        public User EventHost { get; set; }

        //public IEnumerable<Rating> Ratings { get; set; }

        //public IEnumerable<Item> Items { get; set; }


    }
}
