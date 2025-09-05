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

}
