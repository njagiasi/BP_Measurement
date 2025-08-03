using BPMeasurementApp.Entities;
namespace BPMeasurementApp.Models
{
    public class BPMeasurementViewModel
    {
        public List<Position>? Positions { get; set; }

        public BPMeasurement ActiveBPData { get; set; }
    }
}
