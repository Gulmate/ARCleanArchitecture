using UnityEngine;
using UnityEngine.UI;
using VContainer;
public class XRotSliderView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Rotation)]
    private ICubeRotationPresenter cubePresenter;
    private Slider sizeSlider;

    void Start()
    {
        sizeSlider = GameObject.Find("XRotationSlider").GetComponent<Slider>();

        sizeSlider.onValueChanged.AddListener((value) =>
        {
            Vector3 newRotation=cubePresenter.GetCubeRotation();
            newRotation.x = value*360;
            cubePresenter.RotateCube(newRotation);
        }
        );
    }
}
