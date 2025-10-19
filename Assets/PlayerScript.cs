using UnityEngine;
using Mirror;
using System.Net.WebSockets;

public class PlayerScript : NetworkBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    public override void OnStartLocalPlayer()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mainCamera.transform.SetParent(transform);
        mainCamera.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (!isLocalPlayer) { return; }

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);
    }

}
