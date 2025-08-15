namespace SensePlugin.Triggers;

public class AdaptiveTrigger
{
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
    public virtual void ResistMode(TriggerMode mode)
    {
        
    }

    struct LeftTrigger
    {
        
    }
}