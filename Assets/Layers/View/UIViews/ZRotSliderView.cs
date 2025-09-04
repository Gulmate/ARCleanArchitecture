using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class ZRotSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private ICubeRotationPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    private Slider sizeSlider;
    private TextMeshProUGUI ZValueText;
    void Start()
    {
        sizeSlider = GameObject.Find("ZRotationSlider").GetComponent<Slider>();
        ZValueText = GameObject.Find("ZValueText").GetComponent<TextMeshProUGUI>();
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.z = value*360;
            cubePresenter.RotateCube(newRotation);
            ZValueText.text = (value * 360).ToString("F2");
        }
        );
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSlider(float zRot)
    {
        sizeSlider.SetValueWithoutNotify(zRot / 360);
        ZValueText.text = zRot.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSlider(newRotation.z);
    }
}
