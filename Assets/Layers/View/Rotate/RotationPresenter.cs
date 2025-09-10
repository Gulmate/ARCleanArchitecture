using UnityEngine;
using VContainer;

public class RotationPresenter : MonoBehaviour
{
    private RotateUsecase _usecase;

    [Inject]
    public CubeTransformator infrastructure;
    public void AddListenerOnRotationChanged(System.Action<Vector3> listener)
    {
        _usecase.onChange(listener);
    }

    void Awake()
    {
        _usecase = new RotateUsecase(infrastructure);
    }

    public void RotateCube(Vector3 newRotation)
    {
        _usecase.RotateCube(newRotation);
    }

    public Vector3 GetCubeRotation()
    {
        return _usecase.GetCubeRotation();
    }

    public float ChangeX(float value)
    {
        var rotation = GetCubeRotation();
        rotation[0] = value * 360;
        RotateCube(rotation); ;
        return rotation[0];
    }

    public float ChangeY(float value)
    {
        var rotation = GetCubeRotation();
        rotation[1] = value * 360;
        RotateCube(rotation); ;
        return rotation[1];
    }

    public float ChangeZ(float value)
    {
        var rotation = GetCubeRotation();
        rotation[2] = value * 360;
        RotateCube(rotation); ;
        return rotation[2];
    }

}
