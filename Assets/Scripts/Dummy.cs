using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(OnPickedCoroutine());
    }

    private IEnumerator OnPickedCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        InGameManager.Instance.OnDummyPicked();
        Destroy(gameObject);
    }
}
