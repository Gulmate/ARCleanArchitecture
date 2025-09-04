using System;
using UnityEngine;

public interface IScaleUsecase
{
    public void AddListener(System.Action<float> listener);
    public void ResizeCube(float size);
    public float GetCubeSize();
}

public class SizeEventArgs : EventArgs
{
    public float NewSize { get; set; }
    public SizeEventArgs(float newSize)
    {
        NewSize = newSize;
    }
}