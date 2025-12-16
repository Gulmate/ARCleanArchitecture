using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using WebSocketSharp;

public class ConnectPresenter : MonoBehaviour
{
    private SynchronizationContext _mainThreadContext;

    private ConnectUseCase _connectUseCase;


    public event ConnectionStateChange ConnectionStateChanged;
    private WebSocketClientUsecase _websocketusecase;
    private WebSocketStreamingClientUsecase _streamingusecase;

    [Inject]
    private readonly IDocumentationLogger logger;

    [Inject]
    private WebSocketClientService _service;

    [Inject]
    private WebSocketStreamingClientService _streamingService;

    [Inject]
    void Awake()
    {
        _connectUseCase = new ConnectUseCase(logger);
        _websocketusecase = new WebSocketClientUsecase(_service);
        _streamingusecase = new WebSocketStreamingClientUsecase(_streamingService, _service);
    }

    void Start()
    {
        _mainThreadContext = SynchronizationContext.Current;
        _websocketusecase.OnWebSocketStateChange(OnConnectionStateChanged);
    }

    public void Connect(string ip, string port)
    {
        _connectUseCase.Connect(ip, port);
        _websocketusecase.Connect(ip, "8080");
        _connectUseCase.loggerSetup(Application.persistentDataPath);
    }

    public void StartHost(string ip, string port)
    {
        _connectUseCase.StartHost(ip, port);
        _websocketusecase.Connect(ip, "8080");
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

    private void OnConnectionStateChanged(WebSocketState state)
    {
        // Notify subscribers about the connection status change

        if (SynchronizationContext.Current == _mainThreadContext)
        {
            ConnectionStateChanged?.Invoke(state);
        }
        else
        {
            _mainThreadContext.Post(_ =>
            {
                ConnectionStateChanged?.Invoke(state);
            }, null);
        }
    }
}
