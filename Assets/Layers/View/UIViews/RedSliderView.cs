using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class RedSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;
    private Slider redSlider;

    void Start()
    {
        redSlider = GameObject.Find("RedSlider").GetComponent<Slider>();

        redSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.r = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }

}
