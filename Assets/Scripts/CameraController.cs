using UnityEngine;

/// <summary>
/// カメラを制御するクラス
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField, Header("プレイヤー")] private PlayerController player;
    
    [SerializeField, Header("オフセット")] private Vector3 offset;

    void Update()
    {
        
    }
}
