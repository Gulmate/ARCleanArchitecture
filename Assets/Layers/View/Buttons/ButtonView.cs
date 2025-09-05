using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class ButtonView : MonoBehaviour
{
    [Inject]
    [Key(PresenterType.Button)]
    private ButtonPresenter cubePresenter;

    [SerializeField]
    private Button saveButton;
    [SerializeField]
    private Button loadButton;
    void Start()
    {
        saveButton.onClick.AddListener(() =>
        {
            cubePresenter.SaveCube();
        });
        loadButton.onClick.AddListener(() =>
        {
            cubePresenter.LoadCube();
        });
    }
}
