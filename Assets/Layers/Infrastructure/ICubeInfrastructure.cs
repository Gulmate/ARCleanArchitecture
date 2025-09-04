using UnityEngine;

public interface ICubeInfrastructure
{
    public void Rotate(Vector3 angles);
    public Vector3 GetRotation();
    public void ReColor(Color newColor);
    public Color GetColor();
    public void Resize(float newSize);
    public float GetSize();
}
