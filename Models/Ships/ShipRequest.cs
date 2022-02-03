using System.ComponentModel.DataAnnotations;
namespace ShipManagementApi.Models.Ships
{
    public class ShipRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Length { get; set; }

        [Required]
        public float Width { get; set; }

        [Required]
        [MinLength(12)]
        [MaxLength(12)]
        public string Code { get; set; }

    }
}