using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class ZRotSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private ICubeRotationPresenter cubePresenter;
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
    }
}
