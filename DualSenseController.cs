using HidSharp;
using System.Collections.Generic;
namespace SensePlugin;

public static class DualSenseController
{
    public static HidDevice devices;
    // public static bool Initialize()
    // {
    //     var loader = new HidDeviceLoader();
    //
    //     devices = DualSenseHidUtils.FindDualSense();
    //     
    //     return devices == null ? false : devices.Open() != null;
    // }
    public static bool Initialize()
    {
        devices = DualSenseHidUtils.FindDualSense().FirstOrDefault();
        
        
        
        return devices !=  null;
    }
    
    
}