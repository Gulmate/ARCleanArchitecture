using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class SessionView: MonoBehaviour
{
    [Inject]
    private SessionPresenter _sessionPresenter;

    [SerializeField]
    private Button streamButton;

    [SerializeField]
    private Button viewButton;

    public void Start()
    {
        streamButton.onClick.AddListener(() => { _sessionPresenter.ChangeToStream(); });
        viewButton.onClick.AddListener(() => { _sessionPresenter.ChangeToView(); });
    }
}
