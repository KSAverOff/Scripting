using System.IO;
using System.Threading.Tasks;
using HidSharp;
namespace SensePlugin;

public enum TriggerSide
{
    Left, 
    Right
}
public enum TriggerMode : byte
{
    Off = 0x00,
    Linear = 0x01,
    Escalating = 0x02,
    Pulse = 0x06,
    TriggerPull = 0x21,
    Rolling = 0x22,
    Descending = 0x23,
    EndClick = 0x25,
    AutoGun = 0x26,
    Pushing = 0x27
}

public static class DualSenseTrigger
{
    private static HidDevice device;
    private static HidStream stream;

    public static void SetTrigger(TriggerSide side, TriggerMode mode, byte start, byte end, byte force)
    {
        var report = new byte[48];
        report[0] = 0x02;
        report[1] = 0xFF;
        report[2] = 0xF7;

        int offset = (side == TriggerSide.Left) ? 11 : 22;

        report[offset + 0] = (byte)mode;
        report[offset + 1] = end;
        report[offset + 2] = force;
        report[offset + 3] = start;
        report[offset + 4] = 0x00;
        report[offset + 5] = 0x00;
        report[offset + 6] = 0x00;
        report[offset + 7] = 0x00;
        report[offset + 8] = 0x00;
        report[offset + 9] = 0x00;
        report[offset + 10] = 0x00;

        stream?.Write(report);
    }
    
    public static void Reset()
    {
        var report = new byte[48];
        report[0] = 0x02;
        report[1] = 0xFF;
        report[2] = 0x00;
        report[11] = 0x00;
        report[22] = 0x00;
        stream?.Write(report);
    }

    public static void SendCustomReport(byte[] raw)
    {
        if (raw.Length != 48) throw new ArgumentException("Report must be 48 bytes.");
        stream?.Write(raw);
    }
}
