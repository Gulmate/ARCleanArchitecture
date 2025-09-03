using UnityEngine;
using UnityEngine.UI;
public class SizeSliderView : MonoBehaviour
{
    private ICubeSizePresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("SizeSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubeSizePresenter;
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            cubePresenter.ResizeCube(value);
        }
        );
    }
}
