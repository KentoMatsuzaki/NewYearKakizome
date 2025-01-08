using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField, Header("ダイアログキャンバス")] Canvas dialogCanvas;
    [SerializeField, Header("インゲームキャンバス")] Canvas ingameCanvas;
    [SerializeField, Header("話者の名前のテキスト")] TextMeshProUGUI nameText;
    [SerializeField, Header("テキストボックス")] TextMeshProUGUI descriptionText;
    [SerializeField, Header("正月パワー")] Slider powerSlider;
    [SerializeField, Header("ゲージの増加速度")] private float fillSpeed = 1.0f;
    [SerializeField, Header("ゲージの増加量")] private float fillAmount = 0.1f;

    private string message1 = "俺の名前はタカシ！\n俺はとにかく足が速い！\nそして、金にがめつい！";
    private string message2 = "大変だ！タカシくん！\nお正月の力が弱まってる！";
    private string message3 = "みんなのお年玉を集めて\nお正月の力を取り戻さなきゃ！";
    private string message4 = "よし！この俺に任せろ！\nついて来い、ケダモノ！";
    private string message5 = "ありがとうタカシくん。\n君のおかげで正月の力を取り戻せたよ。";
    private string message6 = "これで本当の姿に戻れる。\n";
    private string message7 = "この姿では初めまして、タカシくん。\n私こそが正月の神です。";
    private string message8 = "見てご覧、君のおかげで\n正月の力が満ちているよ。";

    public IEnumerator ShowMessage1()
    {
        nameText.text = "タカシ";
        descriptionText.text = "";
        foreach (var c in message1)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public IEnumerator ShowMessage2()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message2)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator ShowMessage3()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message3)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
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
    
    public IEnumerator ShowMessage5()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message5)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
    public IEnumerator ShowMessage6()
    {
        nameText.text = "ケダモノ";
        descriptionText.text = "";
        foreach (var c in message6)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
    public IEnumerator ShowMessage7()
    {
        nameText.text = "正月の神";
        descriptionText.text = "";
        foreach (var c in message7)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }
    
    public IEnumerator ShowMessage8()
    {
        nameText.text = "正月の神";
        descriptionText.text = "";
        foreach (var c in message8)
        {
            descriptionText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public IEnumerator WaitMessageInterval()
    {
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator EnableDialogCanvas()
    {
        yield return new WaitForSeconds(0.25f);
        dialogCanvas.enabled = true;
    }

    public IEnumerator DisableDialogCanvas()
    {
        yield return new WaitForSeconds(0.25f);
        dialogCanvas.enabled = false;
    }

    public IEnumerator EnableInGameCanvas()
    {
        yield return new WaitForSeconds(0.25f);
        ingameCanvas.enabled = true;
    }

    public IEnumerator DisableInGameCanvas()
    {
        yield return new WaitForSeconds(0.25f);
        ingameCanvas.enabled = false;
    }

    public void AddNewYearPower()
    {
        StartCoroutine(AddNewYearPowerCoroutine());
    }

    private IEnumerator AddNewYearPowerCoroutine()
    {
        float targetPower = Mathf.Min(powerSlider.value + fillAmount, 1.0f);
        while (powerSlider.value < targetPower)
        {
            powerSlider.value = Mathf.MoveTowards(powerSlider.value, targetPower, fillSpeed * Time.deltaTime);
            yield return null;
        }
    }

}
