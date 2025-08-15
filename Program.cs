using System;
using HidSharp;

class Program
{
    static void Main()
    {
        var loader = new HidDeviceLoader();
        var device = loader.GetDevices(0x054C, 0x0CE6).FirstOrDefault(); // USB PID (wired)
        if (device == null)
        {
            Console.WriteLine("DualSense not found.");
            return;
        }

        using var stream = device.Open();

        var report = new byte[48];
        report[0] = 0x02;    // Report ID (USB)
        report[1] = 0xFF;    // Valid flags
        report[2] = 0xF7;    // Enable: rumble + lights + triggers

        // 🎯 Настройки триггера
        byte mode = 0x27;     // Rolling resistance
        byte start = 1;       // Начало сопротивления
        byte end = 9;         // Конец сопротивления
        byte force = 255;     // Сила сопротивления (0–255)
        bool isLeft = true;  // Выбор стороны: true — левый, false — правый
        int offset = isLeft ? 11 : 22;

        // Установка триггера
        report[offset + 0] = mode;
        report[offset + 1] = end;
        report[offset + 2] = force;
        report[offset + 3] = start;
        report[offset + 4] = 0x00; // Unused

        // ⏱️ Timing parameters (влияют на характер сопротивления)
        int timingOffset = 16; // Одни на оба триггера
        report[timingOffset + 0] = 255; // Frequency (0–255)
        report[timingOffset + 1] = 255; // Amplitude (0–255)
        report[timingOffset + 2] = 255;   // Phase (не используется)
        report[timingOffset + 3] = 255;  // Cycle Time (длительность цикла)
        report[timingOffset + 4] = 255;  // Hold Time (удержание)
        report[timingOffset + 5] = 0;   // Reserved

        // 💡 Цвет панели
        report[44] = 0;    // R
        report[45] = 255;  // G
        report[46] = 0;    // B

        stream.Write(report);
        Console.WriteLine("Команда отправлена, жми клавишу для сброса...");
        Console.ReadKey();

        // ❌ Сброс
        var reset = new byte[48];
        reset[0] = 0x02;
        reset[1] = 0xFF;
        reset[2] = 0x00;
        reset[11] = 0x00;
        reset[22] = 0x00;
        stream.Write(reset);
        Console.WriteLine("Сброс отправлен");
    }
}
