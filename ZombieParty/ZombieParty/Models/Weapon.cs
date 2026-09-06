using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon
    {
        [Required]
        [DisplayName("Weapon name")]
        [StringLength(250, MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(2500, MinimumLength = 0)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DisplayName("Force")]
        [Range(0,500)]
        public decimal Force { get; set; }

        [DisplayName("Price")]
        [Range(0, 100000, ErrorMessage = "The {0} has to be between {1} and {2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Date created")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DisplayName("Image")]
        [DataType(DataType.ImageUrl)]
        public string? Image { get; set; }

        [DisplayName("Quantity")]
        public int Qty { get; set; }

        [DisplayName("Quantity bought" )]
        public int QtyBought { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;
            if (item == null) yield break;
            if (string.IsNullOrWhiteSpace(item.Description)) yield break;
            if (item.Description.Split(" ").Length <= 3)
                yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" });
        }

    }
}
