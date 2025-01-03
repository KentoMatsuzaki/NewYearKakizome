using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("キャンバス")] Canvas canvas;
    [SerializeField, Header("話者の名前のテキスト")] TextMeshProUGUI nameText;
    [SerializeField, Header("テキストボックス")] TextMeshProUGUI descriptionText;

    private string message1 = "俺の名前はタカシ！\nそれ以上でもそれ以下でもない！\nいや、俺は足が速い！\nあと、めっちゃ金にがめつい！";
    private string message2 = "大変だ！タカシくん！\nお正月の力が弱まってる！";
    private string message3 = "みんなのお年玉を集めて\nお正月の力を取り戻さなきゃ！";
    private string message4 = "よし！この俺に任せろ！\nついて来い、ポチ！";

    private void Start()
    {
        StartCoroutine(ShowStartMessages());
    }

    private IEnumerator ShowMessage1()
    {
        nameText.text = "タカシ";
        descriptionText.text = "";
        foreach (var c in message1)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator ShowMessage2()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message2)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator ShowMessage3()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message3)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator ShowMessage4()
    {
        nameText.text = "タカシ";
        descriptionText.text = "";
        foreach (var c in message4)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    private IEnumerator WaitMessageInterval()
    {
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator ShowStartMessages()
    {
        yield return ShowMessage1();
        yield return WaitMessageInterval();
        yield return ShowMessage2();
        yield return WaitMessageInterval();
        yield return ShowMessage3();
        yield return WaitMessageInterval();
        yield return ShowMessage4();
        yield return WaitMessageInterval();
        canvas.enabled = false;
    }
}
