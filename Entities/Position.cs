using System.ComponentModel.DataAnnotations;

namespace BPMeasurementApp.Entities
{
    public class Position
    {
        [Key]
        public string PositionId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
