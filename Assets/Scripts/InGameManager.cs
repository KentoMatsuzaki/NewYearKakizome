using UnityEngine;
using System.Collections.Generic;

public class InGameManager : MonoBehaviour
{
    [SerializeField, Header("テレポート地点")] private List<Transform> points = new List<Transform>();
    
    [SerializeField, Header("プレイヤー")] private PlayerController player;
    
    [SerializeField, Header("メインカメラ")] private CameraController mainCamera;
    
    [SerializeField, Header("プレイヤーカメラ")] private Camera playerCamera;
    
    [SerializeField, Header("モンスターカメラ")] private Camera monsterCamera;
    
    private static InGameManager _instance;
    public static InGameManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void OnMoneyPicked(int index)
    {
        player.transform.position = points[index].position;
    }
}