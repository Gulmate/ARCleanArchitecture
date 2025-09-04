using System;
using UnityEngine;

/*public interface ICubePresenter
{
    /*public void Execute<T>(T data);
    public void onChange();
    public T Get<T>();
}*/

public interface ICubeColorPresenter //: ICubePresenter
{
    public void RecolorCube(Color newColor);
    public void AddListenerOnColorChanged(Action<Color> listener);
    public Color GetCubeColor();
}

public interface ICubeSizePresenter //: ICubePresenter
{
    public void ResizeCube(float newSize);
    public void AddListenerOnSizeChanged(Action<float> listener);
    public float GetCubeSize();
}

public interface ICubeRotationPresenter //: ICubePresenter
{
    public void RotateCube(Vector3 newRotation);
    public void AddListenerOnRotationChanged(Action<Vector3> listener);
    public Vector3 GetCubeRotation();
}