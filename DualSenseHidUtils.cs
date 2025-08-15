using HidSharp;

namespace SensePlugin;

public static class DualSenseHidUtils
{
    public static List<HidDevice> FindDualSense()
    {
        var list = DeviceList.Local;
        return list.GetHidDevices(0x054C, 0x0CE6).ToList();
    }
}