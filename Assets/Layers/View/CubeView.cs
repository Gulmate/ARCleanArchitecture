using UnityEngine;

public class CubeView : MonoBehaviour
{
    private ICubeColorPresenter cubeColorPresenter;
    private ICubeSizePresenter cubeSizePresenter;
    private ICubeRotationPresenter cubeRotationPresenter;
    private GameObject cube;

    private void Start()
    {
        cube=GameObject.Find("Cube");
        cubeColorPresenter = PresenterDI.cubeColorPresenter;
        cubeColorPresenter.AddListenerOnColorChanged(onColorChanged);

        cubeSizePresenter = PresenterDI.cubeSizePresenter;
        cubeSizePresenter.AddListenerOnSizeChanged(onSizeChanged);

        cubeRotationPresenter = PresenterDI.cubeRotationPresenter;
        cubeRotationPresenter.AddListenerOnRotationChanged(onRotationChanged);

    }

    void onColorChanged(Color newColor)
    {
        UpdateCubeColor(newColor);
    }

    void onSizeChanged(float newSize)
    {
        UpdateCubeSize(newSize);
    }

    void onRotationChanged(Vector3 newRotation)
    {
        cube.transform.eulerAngles = newRotation;
    }

    private void UpdateCubeColor(Color newColor)
    {
        cube.GetComponent<Renderer>().material.color = newColor;
    }

    private void UpdateCubeSize(float newSize)
    {
        cube.transform.localScale = new Vector3(newSize, newSize, newSize);
    }

    private void UpdateCubeRotation(Vector3 newRotation)
    {
        cube.transform.rotation = new Quaternion(newRotation.x,newRotation.y,newRotation.z,0);
    }

}
