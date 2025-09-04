using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class BlueSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;
    private Slider blueSlider;
    private TextMeshProUGUI blueValueText;

    void Start()
    {
        blueSlider = GameObject.Find("BlueSlider").GetComponent<Slider>();
        blueValueText = GameObject.Find("BlueValueText").GetComponent<TextMeshProUGUI>();
        blueSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.b = value;
            cubePresenter.RecolorCube(newColor);
            blueValueText.text = cubePresenter.GetCubeColor().b.ToString("F2");
        }
        );
    }
}
