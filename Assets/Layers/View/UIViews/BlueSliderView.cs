using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class BlueSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;
    private Slider blueSlider;

    void Start()
    {
        blueSlider = GameObject.Find("BlueSlider").GetComponent<Slider>();

        blueSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.b = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
