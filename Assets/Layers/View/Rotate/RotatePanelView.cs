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
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.x = value * 360;
            cubePresenter.RotateCube(newRotation);
            XValueText.text = (value * 360).ToString("F2");
        }
        );


        ySlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.y = value * 360;
            cubePresenter.RotateCube(newRotation);
            YValueText.text = (value * 360).ToString("F2");
        }
        );


        zSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.z = value * 360;
            cubePresenter.RotateCube(newRotation);
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
