using System;

public class SizeEventArgs : EventArgs
{
    public float NewSize { get; set; }
    public SizeEventArgs(float newSize)
    {
        NewSize = newSize;
    }
}
