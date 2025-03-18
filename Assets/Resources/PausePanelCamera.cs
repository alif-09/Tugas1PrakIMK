using UnityEngine;

public class PausePanelCamera : MonoBehaviour
{
    public Transform playerCamera;

    void Update()
    {
        transform.position = playerCamera.position + playerCamera.forward * 2f; // Atur jarak di depan kamera
        transform.rotation = Quaternion.LookRotation(playerCamera.forward); // Menghadap kamera
    }
}