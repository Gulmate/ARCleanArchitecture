using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class RedSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private ICubeColorPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    private Slider redSlider;
    private TextMeshProUGUI redValueText;

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
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSlider(float red)
    {
        redSlider.SetValueWithoutNotify(red);
        redValueText.text = red.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSlider(newColor.r);
        
    }
}
