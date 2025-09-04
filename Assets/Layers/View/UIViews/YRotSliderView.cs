using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class YRotSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private ICubeRotationPresenter cubePresenter;
    private Slider sizeSlider;
    private TextMeshProUGUI YValueText;
    void Start()
    {
        sizeSlider = GameObject.Find("YRotationSlider").GetComponent<Slider>();
        YValueText = GameObject.Find("YValueText").GetComponent<TextMeshProUGUI>();
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.y = value*360;
            cubePresenter.RotateCube(newRotation);
            YValueText.text = (value * 360).ToString("F2");
        }
        );
    }
}
