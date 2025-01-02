using UnityEngine;

/// <summary>
/// カメラを制御するクラス
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField, Header("プレイヤー")] private PlayerController player;
    
    [SerializeField, Header("オフセット")] private Vector3 offset;

    [SerializeField, Header("追従する速度")] private float smoothSpeed = 0.125f;
    
    private Vector3 _currentOffset;

    void LateUpdate()
    {
        _currentOffset = player.transform.rotation * offset;
        var desiredPos = player.transform.position + _currentOffset;
        var fixedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = fixedPos;
        transform.LookAt(player.transform.position + Vector3.up * 0.75f);
    }
}
