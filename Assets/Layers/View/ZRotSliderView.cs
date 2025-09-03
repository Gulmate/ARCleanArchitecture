using UnityEngine;
using UnityEngine.UI;
public class ZRotSliderView : MonoBehaviour
{
    private ICubeRotationPresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("ZRotationSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeRotationPresenter;
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.z = value*360;
            cubePresenter.RotateCube(newRotation);
        }
        );
    }
}
