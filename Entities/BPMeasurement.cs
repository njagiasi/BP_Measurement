using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPMeasurementApp.Entities
{
    public class BPMeasurement
    {
        public int BPMeasurementId { get; set; }

        [Required(ErrorMessage = "Systolic value is required.")]
        [Range(20, 400, ErrorMessage = "Systolic must be between 20 and 400.")]
        public int Systolic { get; set; }

        [Required(ErrorMessage = "Diastolic value is required.")]
        [Range(10, 300, ErrorMessage = "Diastolic must be between 10 and 300.")]
        public int Diastolic { get; set; }

        [Required(ErrorMessage = "Measurement date is required.")]
        [DataType(DataType.Date)]
        public DateTime MeasurementDate { get; set; }

        [Required(ErrorMessage = "Please specify a position.")]
        public string? PositionId { get; set; }

        [ForeignKey("PositionId")] // Explicitly specify the foreign key
        public Position? Position { get; set; }

        public string Category
        {
            get
            {
                if (Systolic >= 180 || Diastolic >= 120)
                    return "Hypertensive Crisis"; // Hypertensive Crisis

                if (Systolic >= 140 || Diastolic >= 90)
                    return "Hypertension Stage 2"; // Hypertension Stage 2

                if ((Systolic >= 130 && Systolic < 140) || (Diastolic >= 80 && Diastolic < 90))
                    return "Hypertension Stage 1"; // Hypertension Stage 1

                if (Systolic >= 120 && Systolic < 130 && Diastolic < 80)
                    return "Elevated"; // Elevated

                if (Systolic < 120 && Diastolic < 80)
                    return "Normal"; // Normal

                return "Unknown"; // Default case
            }
        }



    }
}
