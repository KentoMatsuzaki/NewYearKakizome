using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Point : MonoBehaviour
{
    [SerializeField, Header("プレイヤー")] private Transform player;

    [SerializeField, Header("回転角度")] private float rotationY;
    
    [SerializeField, Header("トレイル")] private Transform trail;

    private void OnTriggerEnter(Collider other)
    {
        player.rotation = Quaternion.Euler(player.rotation.x, rotationY, player.rotation.z);
        trail.gameObject.SetActive(true);
    }
}
