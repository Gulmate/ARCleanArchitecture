using UnityEngine;
using UnityEngine.UI;

public class YRotSliderView : MonoBehaviour
{
    private ICubeRotationPresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("YRotationSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeRotationPresenter;
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.y = value*360;
            cubePresenter.RotateCube(newRotation);
        }
        );
    }
}
