using Mirror;
using TMPro;
using UnityEngine;

public class SyncView : NetworkBehaviour
{
    [SyncVar]
    private string textSync;

    [SerializeField]
    private TMP_InputField input;

    void Start()
    {
        input.onEndEdit.AddListener((value) => { textSync = input.text; });
    }

}
