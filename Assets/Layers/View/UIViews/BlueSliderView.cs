using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class BlueSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

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
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSlider(float blue)
    {
        blueSlider.SetValueWithoutNotify(blue);
        blueValueText.text = blue.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSlider(newColor.b);

    }
}
