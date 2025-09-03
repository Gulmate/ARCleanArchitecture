using UnityEngine;

public class CubeView : MonoBehaviour
{
    private ICubePresenter cubePresenter;
    private GameObject cube;

    private void Start()
    {
        cube=GameObject.Find("Cube");
        cubePresenter = PresenterDI.cubePresenter;
        cubePresenter.AddListenerOnColorChanged(onColorChanged);

        UpdateCube(new Color(0,0,0,1));
    }

    void onColorChanged(Color newColor)
    {
        UpdateCube(newColor);
        Debug.Log(newColor);
    }

    private void UpdateCube(Color newColor)
    {
        cube.GetComponent<Renderer>().material.color = newColor;
    }

}
