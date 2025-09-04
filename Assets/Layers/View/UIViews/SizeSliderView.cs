using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class SizeSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Size)]
    private ICubeSizePresenter cubePresenter;
    private Slider sizeSlider;
    private TextMeshProUGUI sizeValueText;

    void Start()
    {
        sizeSlider = GameObject.Find("SizeSlider").GetComponent<Slider>();
        sizeValueText = GameObject.Find("ScaleValueText").GetComponent<TextMeshProUGUI>();
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            cubePresenter.ResizeCube(value);
            sizeValueText.text = cubePresenter.GetCubeSize().ToString("F2");
        }
        );
    }
}
