using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("キャンバス")] Canvas canvas;
    [SerializeField, Header("話者の名前のテキスト")] TextMeshProUGUI nameText;
    [SerializeField, Header("テキストボックス")] TextMeshProUGUI descriptionText;

    private string message1 = "俺の名前はタカシ！\n俺はとにかく足が速い！\nそして金にがめつい！";
    private string message2 = "大変だ！タカシくん！\nお正月の力が弱まってる！";
    private string message3 = "みんなのお年玉を集めて\nお正月の力を取り戻さなきゃ！";
    private string message4 = "よし！この俺に任せろ！\nついて来い、ポチ！";

    public IEnumerator ShowMessage1()
    {
        nameText.text = "タカシ";
        descriptionText.text = "";
        foreach (var c in message1)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator ShowMessage2()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message2)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    public IEnumerator ShowMessage3()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message3)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.15f);
        }
    }

    public IEnumerator ShowMessage4()
    {
        nameText.text = "タカシ";
        descriptionText.text = "";
        foreach (var c in message4)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator WaitMessageInterval()
    {
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator EnableCanvas()
    {
        yield return new WaitForSeconds(0.25f);
        canvas.enabled = true;
    }

    public IEnumerator DisableCanvas()
    {
        yield return new WaitForSeconds(0.25f);
        canvas.enabled = false;
    }
}
