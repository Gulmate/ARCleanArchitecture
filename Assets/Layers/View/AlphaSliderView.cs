using UnityEngine;
using UnityEngine.UI;
public class NewMonoBehaviourScript : MonoBehaviour
{

    private ICubePresenter cubePresenter;
    private Slider alphaSlider;

    void Start()
    {
        alphaSlider = GameObject.Find("AlphaSlider").GetComponent<Slider>();

        cubePresenter = PresenterDI.cubePresenter;
        alphaSlider.onValueChanged.AddListener((value) =>
        {
            Color newColor = cubePresenter.GetCubeColor();
            newColor.a = value;
            cubePresenter.RecolorCube(newColor);
        }
        );
    }
}
