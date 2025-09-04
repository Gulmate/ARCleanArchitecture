using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class GreenSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;
    private Slider greenSlider;
    private TextMeshProUGUI greenValueText;

    void Start()
    {
        greenSlider = GameObject.Find("GreenSlider").GetComponent<Slider>();
        greenValueText = GameObject.Find("GreenValueText").GetComponent<TextMeshProUGUI>();
        greenSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.g = value;
            cubePresenter.RecolorCube(newColor);
            greenValueText.text = cubePresenter.GetCubeColor().g.ToString("F2");
        }
        );
    }
}
