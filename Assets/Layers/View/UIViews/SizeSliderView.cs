using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class SizeSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Size)]
    private ICubeSizePresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("SizeSlider").GetComponent<Slider>();

        sizeSlider.onValueChanged.AddListener((value) =>
        {
            cubePresenter.ResizeCube(value);
        }
        );
    }
}
