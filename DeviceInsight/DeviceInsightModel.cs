using System;

namespace DeviceInsight.Models
{
    public class BatteryInfo
    {
        public int Id { get; set; }
        public int EstimatedTimeLeft { get; set; }
        public int DesignedCapacity { get; set; }
        public int FullChargedCapacity { get; set; }
        public float BatteryHealth { get; set; }
    }
}
