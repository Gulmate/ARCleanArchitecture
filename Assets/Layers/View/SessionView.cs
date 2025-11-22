using UnityEngine;
using UnityEngine.UI;

public class SessionView: MonoBehaviour
{
    private CustomNetworkManager networkManager;

    [SerializeField]
    private Button streamButton;

    [SerializeField]
    private Button viewButton;

    public void Start()
    {
        networkManager = GameObject.Find("NetworkManager").GetComponent<CustomNetworkManager>();

        streamButton.onClick.AddListener(() => { networkManager.ChangeSceneToStream(); });
        viewButton.onClick.AddListener(() => { networkManager.ChangeSceneToView(); });
    }
}
