using System;
using UnityEngine;

public class RotationPresenter : MonoBehaviour, ICubeRotationPresenter
{
    private RotateUsecase _usecase;

    public void AddListenerOnRotationChanged(System.Action<Vector3> listener)
    {
        _usecase.OnRotationChanged += new System.EventHandler<RotateEventArgs>(delegate (object sender, RotateEventArgs event_arg)
        {
            listener(event_arg.rotation);
        });
    }

    void Awake()
    {
        CubeInfrastructure infrastructure = new CubeInfrastructure();
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
