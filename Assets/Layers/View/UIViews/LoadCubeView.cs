using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class CubeLoadView: MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter cubePresenter;
    private Button loadButton;
    void Start()
    {
        loadButton = GameObject.Find("LoadButton").GetComponent<Button>();
        loadButton.onClick.AddListener(() =>
        {
            cubePresenter.LoadCube();
        });
    }
}
