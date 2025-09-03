using UnityEngine;
using UnityEngine.UI;

public class BlueSliderView : MonoBehaviour
{
    private ICubeColorPresenter cubePresenter;
    private Slider blueSlider;

    void Start()
    {
        blueSlider = GameObject.Find("BlueSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeColorPresenter;
        blueSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.b = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
