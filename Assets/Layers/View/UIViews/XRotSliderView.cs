using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class XRotSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private ICubeRotationPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    private Slider sizeSlider;
    private TextMeshProUGUI XValueText;

    void Start()
    {
        sizeSlider = GameObject.Find("XRotationSlider").GetComponent<Slider>();
        XValueText = GameObject.Find("XValueText").GetComponent<TextMeshProUGUI>();
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation=cubePresenter.GetCubeRotation();
            newRotation.x = value*360;
            cubePresenter.RotateCube(newRotation);
            XValueText.text = (value * 360).ToString("F2");
        }
        );
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSlider(float xRot)
    {
        sizeSlider.SetValueWithoutNotify(xRot / 360);
        XValueText.text = xRot.ToString("F2");
    }
    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSlider(newRotation.x);
    }
}
