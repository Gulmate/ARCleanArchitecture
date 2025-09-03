using UnityEngine;

public class CubeInfrastructure
{
    private readonly Cube cube= new Cube();

    public void Rotate(Vector3 angles)
    {
        cube.rotation = angles;
    }
    public Vector3 GetRotation()
    {
        return cube.rotation;
    }

    public void ReColor(Color newColor)
    {
        cube.color = newColor;
    }

    public Color GetColor()
    {
        return cube.color;
    }

    public void Resize(float newSize)
    {
        cube.size = newSize;
    }

    public float GetSize()
    {
        return cube.size;
    }
}
