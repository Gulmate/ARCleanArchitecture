using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class GreenSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;
    private Slider greenSlider;

    void Start()
    {
        greenSlider = GameObject.Find("GreenSlider").GetComponent<Slider>();

        greenSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.g = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
