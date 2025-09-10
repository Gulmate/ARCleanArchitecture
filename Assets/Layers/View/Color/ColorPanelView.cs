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

    [SerializeField]
    private Slider redSlider;
    [SerializeField]
    private TextMeshProUGUI redValueText;

    [SerializeField]
    private Slider greenSlider;
    [SerializeField]
    private TextMeshProUGUI greenValueText;

    [SerializeField]
    private Slider blueSlider;
    [SerializeField]
    private TextMeshProUGUI blueValueText;

    [SerializeField]
    private Slider alphaSlider;
    [SerializeField]
    private TextMeshProUGUI alphaValueText;

    void Start()
    {
        redSlider.onValueChanged.AddListener((value) =>
        {
            var r = cubePresenter.ChangeRed(value);
            redValueText.text = r.ToString("F2");
        });

        greenSlider.onValueChanged.AddListener((value) =>
        {
            var g = cubePresenter.ChangeGreen(value);
            greenValueText.text = g.ToString("F2");
        });

        blueSlider.onValueChanged.AddListener((value) =>
        {
            var b = cubePresenter.ChangeBlue(value);
            blueValueText.text = b.ToString("F2");
        });

        alphaSlider.onValueChanged.AddListener((value) =>
        {
            var a = cubePresenter.ChangeAlpha(value);
            alphaValueText.text = a.ToString("F2");
        });

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
