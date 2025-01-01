using UnityEngine;

/// <summary>
/// マウスを制御するクラス
/// </summary>
public class MouseController : MonoBehaviour
{
    [SerializeField, Header("マウス感度")] private float mouseSensitivity = 100f;
    
    [SerializeField, Header("プレイヤー")] private PlayerController player;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        player.transform.Rotate(Vector3.up * mouseX);
    }
}
