using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ColorPanelView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private RecolorPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    private Slider redSlider;
    private TextMeshProUGUI redValueText;

    private Slider greenSlider;
    private TextMeshProUGUI greenValueText;

    private Slider blueSlider;
    private TextMeshProUGUI blueValueText;

    private Slider alphaSlider;
    private TextMeshProUGUI alphaValueText;

    void Start()
    {
        redSlider = GameObject.Find("RedSlider").GetComponent<Slider>();
        redValueText = GameObject.Find("RedValueText").GetComponent<TextMeshProUGUI>();
        redSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.r = value;
            cubePresenter.RecolorCube(newColor);
            redValueText.text = cubePresenter.GetCubeColor().r.ToString("F2");
        }
        );
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
        alphaSlider = GameObject.Find("AlphaSlider").GetComponent<Slider>();
        alphaValueText = GameObject.Find("AlphaValueText").GetComponent<TextMeshProUGUI>();

        alphaSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.a = value;
            cubePresenter.RecolorCube(newColor);
            alphaValueText.text = cubePresenter.GetCubeColor().a.ToString("F2");
        }
        );
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSliders(float red, float green, float blue, float alpha)
    {
        redSlider.SetValueWithoutNotify(red);
        redValueText.text = red.ToString("F2");
        greenSlider.SetValueWithoutNotify(green);
        greenValueText.text = green.ToString("F2");
        blueSlider.SetValueWithoutNotify(blue);
        blueValueText.text = blue.ToString("F2");
        alphaSlider.SetValueWithoutNotify(alpha);
        alphaValueText.text = alpha.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSliders(newColor.r, newColor.g, newColor.b, newColor.a);

    }
}
