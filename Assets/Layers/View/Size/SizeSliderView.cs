using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class SizeSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Size)]
    private ResizePresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    [SerializeField]
    private Slider sizeSlider;
    [SerializeField]
    private TextMeshProUGUI sizeValueText;

    void Start()
    {
        sizeSlider.onValueChanged.AddListener((value) =>
        {
            cubePresenter.ResizeCube(value);
            sizeValueText.text = cubePresenter.GetCubeSize().ToString("F2");
        }
        );
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSlider(float size)
    {
        sizeSlider.SetValueWithoutNotify(size);
        sizeValueText.text = size.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSlider(newSize);
    }
}
