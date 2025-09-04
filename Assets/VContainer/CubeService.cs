using UnityEngine;
using UnityEngine.UI;

public class CubeService
{
    public void LogCubeSize(float size)
    {
        Debug.Log($"Cube size is: {size}");
    }
}

public class SizeModel
{
    public Slider slider { get; private set; }
    public void SetSize(Slider newSlider)
    {
        slider = newSlider;
    }
}
