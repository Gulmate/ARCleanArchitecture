using System;
using UnityEngine;

/*public interface ICubePresenter: ICubeColorPresenter, ICubeSizePresenter
{
    
}*/

public interface ICubeColorPresenter
{
    public void RecolorCube(Color newColor);
    public void AddListenerOnColorChanged(Action<Color> listener);
    public Color GetCubeColor();
}

public interface ICubeSizePresenter
{
    public void ResizeCube(float newSize);
    public void AddListenerOnSizeChanged(Action<float> listener);
    public float GetCubeSize();
}

public interface ICubeRotationPresenter
{
    public void RotateCube(Vector3 newRotation);
    public void AddListenerOnRotationChanged(Action<Vector3> listener);
    public Vector3 GetCubeRotation();
}