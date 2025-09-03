using UnityEngine;
using UnityEngine.UI;
public class XRotSliderView : MonoBehaviour
{
    private ICubeRotationPresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("XRotationSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeRotationPresenter;
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation=cubePresenter.GetCubeRotation();
            newRotation.x = value*360;
            cubePresenter.RotateCube(newRotation);
        }
        );
    }
}
