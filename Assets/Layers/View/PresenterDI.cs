using UnityEngine;

public class PresenterDI: MonoBehaviour
{
    public static ICubeColorPresenter cubeColorPresenter;
    public static ICubeSizePresenter cubeSizePresenter;
    public static ICubeRotationPresenter cubeRotationPresenter;
    void Awake()
    {
        cubeColorPresenter = gameObject.AddComponent<RecolorPresenter>();
        cubeSizePresenter = gameObject.AddComponent<ResizePresenter>();
        cubeRotationPresenter = gameObject.AddComponent<RotationPresenter>();
    }
}
