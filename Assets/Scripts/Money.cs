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
        if (itemNumber == 10)
        {
            StartCoroutine(OnLastPickedCoroutine());
        }
        else
        {
            StartCoroutine(OnPickedCoroutine());
        }
    }

    private IEnumerator OnPickedCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        trail.SetParent(null);
        InGameManager.Instance.OnMoneyPicked(itemNumber);
        Destroy(gameObject);
    }

    private IEnumerator OnLastPickedCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        InGameManager.Instance.OnLastMoneyPicked();
        Destroy(gameObject);
    }
}
