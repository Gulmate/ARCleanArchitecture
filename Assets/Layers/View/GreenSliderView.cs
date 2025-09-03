using UnityEngine;
using UnityEngine.UI;
public class GreenSliderView : MonoBehaviour
{
    private ICubeColorPresenter cubePresenter;
    private Slider greenSlider;

    void Start()
    {
        greenSlider = GameObject.Find("GreenSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeColorPresenter;
        greenSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.g = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
