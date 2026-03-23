using DeviceInsight.Models;
using System.Collections.ObjectModel;
using System.Management;

namespace DeviceInsight.ViewModels
{
    public class BatteryHealthViewModel
    {
        private ObservableCollection<BatteryInfo> _batteryInfos;
        public ObservableCollection<BatteryInfo> BatteryInfos
        {
            get { return _batteryInfos; }
            set { _batteryInfos = value; }
        }

        public BatteryHealthViewModel()
        {
            BatteryInfos = new ObservableCollection<BatteryInfo>(GetBatteryInfoData());
        }

        private List<BatteryInfo> GetBatteryInfoData()
        {
            var batteryInfoData = new List<BatteryInfo>();
            try
            {
                using (ManagementObjectSearcher wmiObject = new ManagementObjectSearcher("select * from Win32_battery"))
                {
                    int count = 1;
                    string uniqueId = string.Empty;
                    string instanceName = string.Empty;
                    foreach (ManagementObject obj in wmiObject.Get())
                    {
                        var batteryInfo = new BatteryInfo();
                        batteryInfo.Id = count++;
                        uniqueId = obj["DeviceID"]?.ToString() ?? string.Empty;
                        batteryInfo.EstimatedTimeLeft = Convert.ToInt32(obj["EstimatedRunTime"] ?? 0);
                        using (var searcher = new ManagementObjectSearcher(@"root\WMI", $"select InstanceName, DesignedCapacity from BatteryStaticData where UniqueID='{uniqueId}'"))
                        {
                            ManagementObject staticDataObj = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                            instanceName = staticDataObj?["InstanceName"]?.ToString() ?? string.Empty;
                            batteryInfo.DesignedCapacity = Convert.ToInt32(staticDataObj?["DesignedCapacity"] ?? 0);
                        }
                        instanceName = instanceName.Replace(@"\", @"\\");
                        using (var searcher = new ManagementObjectSearcher(@"root\WMI", $"select FullChargedCapacity from BatteryFullChargedCapacity where InstanceName='{instanceName}'"))
                        {
                            ManagementObject fullChargedObj = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
                            batteryInfo.FullChargedCapacity = Convert.ToInt32(fullChargedObj?["FullChargedCapacity"] ?? 0);
                        }
                        batteryInfo.BatteryHealth = batteryInfo.DesignedCapacity > 0 
                            ? (float)batteryInfo.FullChargedCapacity / batteryInfo.DesignedCapacity * 100 : 0;
                        batteryInfoData.Add(batteryInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching battery info: {ex.Message}");
            }
            return batteryInfoData;
        }
    }
}