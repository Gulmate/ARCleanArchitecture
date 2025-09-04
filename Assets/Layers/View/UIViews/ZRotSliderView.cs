using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class ZRotSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private ICubeRotationPresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("ZRotationSlider").GetComponent<Slider>();

        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation = cubePresenter.GetCubeRotation();
            newRotation.z = value*360;
            cubePresenter.RotateCube(newRotation);
        }
        );
    }
}
