
namespace SensePlugin;

public enum LedColor
{
    Off,
    Red,
    Green,
    Blue,
    White,
    Yellow,
    Orange,
    Pink,
    Purple,
    Lime,
    Cyan
}


public static class DualSenseLED
{
    private static readonly Dictionary<LedColor, (byte r, byte g, byte b)> LedColors = new()
    {
        {LedColor.Off, (0, 0, 0)},
        {LedColor.Red, (255, 0, 0)},
        {LedColor.Green, (255, 0, 0)},
        {LedColor.Blue, (255, 0, 0)},
        {LedColor.White, (255, 0, 0)},
        {LedColor.Yellow, (255, 0, 0)},
        {LedColor.Orange, (255, 0, 0)},
        {LedColor.Pink, (255, 0, 0)},
        {LedColor.Purple, (255, 0, 0)},
        {LedColor.Lime, (255, 0, 0)},
        {LedColor.Cyan, (255, 0, 0)}
    };
    public static (byte r, byte g, byte b) GetRGB(LedColor color) => LedColors[color];

    public static void SetLED(LedColor color)
    {
        
    }
}