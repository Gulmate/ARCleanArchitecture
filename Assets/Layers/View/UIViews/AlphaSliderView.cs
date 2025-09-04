using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class AlphaSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;
    private Slider alphaSlider;

    void Start()
    {
        alphaSlider = GameObject.Find("AlphaSlider").GetComponent<Slider>();

        alphaSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.a = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
