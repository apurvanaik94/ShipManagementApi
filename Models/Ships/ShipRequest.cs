using System.ComponentModel.DataAnnotations;
namespace ShipManagementApi.Models.Ships
{
    public class ShipRequest
    {
        public string Name { get; set; }

        [Required]
        [Range(0.01, 999999999)]
        public float Length { get; set; }

        [Required]
        [Range(0.01, 999999999)]
        public float Width { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12)]
        [RegularExpression(@"[A-Z]{4}\-([0-9]{4})\-([A-Z][0-9])")]
        public string Code { get; set; }

    }
}