using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class ConnectPresenter : MonoBehaviour
{
    private ConnectUseCase _connectUseCase;

    [Inject]
    private readonly IDocumentationLogger logger;

    [Inject]
    void Awake()
    {
        _connectUseCase = new ConnectUseCase(logger);
    }

    public void Connect(string ip, string port)
    {
        
        _connectUseCase.Connect(ip, port);
        _connectUseCase.loggerSetup(Application.persistentDataPath);
    }

    public void StartHost(string ip, string port)
    {
        _connectUseCase.StartHost(ip, port);
        _connectUseCase.loggerSetup(Application.persistentDataPath);
    }

    public void SetToOnline(CustomNetworkManager manager)
    {
        _connectUseCase.SetToOnline(manager);
    }

    public void ChangeToOfflineScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
