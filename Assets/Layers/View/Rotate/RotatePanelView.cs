using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class RotatePanelView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private RotationPresenter cubePresenter;

    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter buttonPresenter;

    [SerializeField]
    private Slider xSlider;
    [SerializeField]
    private TextMeshProUGUI ZValueText;

    [SerializeField]
    private Slider ySlider;
    [SerializeField]
    private TextMeshProUGUI YValueText;

    [SerializeField]
    private Slider zSlider;
    [SerializeField]
    private TextMeshProUGUI XValueText;

    void Start()
    {
        xSlider.onValueChanged.AddListener((value) =>
        {
            float x = cubePresenter.ChangeX(value);
            XValueText.text = (value * 360).ToString("F2");
        }
        );


        ySlider.onValueChanged.AddListener((value) =>
        {
            float y = cubePresenter.ChangeY(value);
            YValueText.text = (value * 360).ToString("F2");
        }
        );


        zSlider.onValueChanged.AddListener((value) =>
        {
            float z = cubePresenter.ChangeZ(value);
            ZValueText.text = (value * 360).ToString("F2");
        }
        );
        buttonPresenter.AddListenerOnPressed(onClicked);
    }

    public void UpdateSliders(float xRot, float yRot, float zRot)
    {
        xSlider.SetValueWithoutNotify(xRot / 360);
        XValueText.text = xRot.ToString("F2");
        ySlider.SetValueWithoutNotify(yRot / 360);
        YValueText.text = yRot.ToString("F2");
        zSlider.SetValueWithoutNotify(zRot / 360);
        ZValueText.text = zRot.ToString("F2");
    }

    private void onClicked(float newSize, Color newColor, Vector3 newRotation)
    {
        UpdateSliders(newRotation.z, newRotation.y, newRotation.z);
    }
}
