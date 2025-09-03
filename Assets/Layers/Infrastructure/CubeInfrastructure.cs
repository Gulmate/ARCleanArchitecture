using UnityEngine;

public class CubeInfrastructure
{
    private readonly CubeSize cubeSize=new CubeSize();
    private readonly CubeColor cubeColor= new CubeColor();
    private readonly CubeRotation cubeRotation= new CubeRotation();


    public void Rotate(Vector3 angles)
    {
        cubeRotation.angles = angles;
    }
    public Vector3 GetRotation()
    {

        return cubeRotation.angles;
    }

    public void ReColor(Color newColor)
    {
        cubeColor.color = newColor;
    }

    public Color GetColor()
    {
        return cubeColor.color;
    }

    public void Resize(float newSize)
    {
        cubeSize.size = newSize;
    }

    public float GetSize()
    {
        return cubeSize.size;
    }
}
