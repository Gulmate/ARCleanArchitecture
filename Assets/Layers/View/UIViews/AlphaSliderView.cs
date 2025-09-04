using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class AlphaSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    private Slider alphaSlider;
    private TextMeshProUGUI alphaValueText;

    void Start()
    {
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

    public void UpdateSlider(float alpha)
    {
        alphaSlider.SetValueWithoutNotify(alpha);
        alphaValueText.text = alpha.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSlider(newColor.a);

    }
}
