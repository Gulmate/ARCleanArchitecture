using UnityEngine;
using UnityEngine.UI;
public class AlphaSliderView : MonoBehaviour
{

    private ICubeColorPresenter cubePresenter;
    private Slider alphaSlider;

    void Start()
    {
        alphaSlider = GameObject.Find("AlphaSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeColorPresenter;
        alphaSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.a = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
