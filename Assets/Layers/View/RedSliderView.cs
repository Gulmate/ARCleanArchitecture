using UnityEngine;
using UnityEngine.UI;

public class RedSliderView : MonoBehaviour
{
    private ICubePresenter cubePresenter;
    private Slider redSlider;

    void Start()
    {
        redSlider = GameObject.Find("RedSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubePresenter;
        redSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.r = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }

}
