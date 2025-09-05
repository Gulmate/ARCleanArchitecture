using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class CubeSaveView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter cubePresenter;
    private Button saveButton;
    void Start()
    {
        saveButton = GameObject.Find("SaveButton").GetComponent<Button>();
        saveButton.onClick.AddListener(() =>
        {
            cubePresenter.SaveCube();
        });
    }

}
