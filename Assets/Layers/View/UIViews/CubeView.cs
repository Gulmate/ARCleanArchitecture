using UnityEngine;
using VContainer;

public class CubeView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Color)]
    private readonly ICubeColorPresenter cubeColorPresenter;

    [Inject]
    [Key(PresenterType.Size)]
    private readonly ICubeSizePresenter cubeSizePresenter;

    [Inject]
    [Key(PresenterType.Rotation)]
    private readonly ICubeRotationPresenter cubeRotationPresenter;
    private GameObject cube;

    private void Start()
    {
        cube =GameObject.Find("Cube");
        cubeColorPresenter.AddListenerOnColorChanged(onColorChanged);
        cubeSizePresenter.AddListenerOnSizeChanged(onSizeChanged);
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
        UpdateCubeRotation(newRotation);
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
