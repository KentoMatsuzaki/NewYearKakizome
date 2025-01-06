using System.Collections;
using UnityEngine;

/// <summary>
/// お金にアタッチするクラス
/// </summary>
public class Money : MonoBehaviour
{
    [SerializeField, Header("取得時のイベント")] private int itemNumber;

    [SerializeField, Header("トレイル")] private Transform trail;
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(OnPickedCoroutine());
    }

    private IEnumerator OnPickedCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        trail.SetParent(null);
        InGameManager.Instance.OnMoneyPicked(itemNumber);
        Destroy(gameObject);
    }
}
