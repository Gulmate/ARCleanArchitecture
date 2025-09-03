using UnityEngine;

public class PresenterDI: MonoBehaviour
{
    public static ICubePresenter cubePresenter;
    void Awake()
    {
        cubePresenter = gameObject.AddComponent<RecolorPresenter>();
    }
}
