using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameManager : MonoBehaviour
{
    [SerializeField, Header("テレポート地点")] private List<Transform> points = new List<Transform>();
    
    [SerializeField, Header("プレイヤー")] private PlayerController player;
    
    [SerializeField, Header("メインカメラ")] private Camera mainCamera;
    
    [SerializeField, Header("プレイヤーカメラ")] private Camera playerCamera;
    
    [SerializeField, Header("モンスターカメラ")] private Camera monsterCamera;
    
    [SerializeField, Header("UIマネージャー")] private UIManager uiManager;
    
    [SerializeField, Header("チュートリアルスキップ")] private bool isSkipTutorial;
    
    private static InGameManager _instance;
    public static InGameManager Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (!isSkipTutorial) StartCoroutine(StartScene());
    }

    private IEnumerator StartScene()
    {
        yield return uiManager.EnableDialogCanvas();
        yield return uiManager.DisableInGameCanvas();
        yield return ActivatePlayerCamera();
        yield return uiManager.ShowMessage1();
        yield return uiManager.WaitMessageInterval();
        yield return ActivateMonsterCamera();
        yield return uiManager.ShowMessage2();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.ShowMessage3();
        yield return uiManager.WaitMessageInterval();
        yield return ActivatePlayerCamera();
        yield return uiManager.ShowMessage4();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.DisableDialogCanvas();
        yield return ActivateMainCamera();
        yield return uiManager.EnableInGameCanvas();
    }

    private IEnumerator ActivateMainCamera()
    {
        yield return new WaitForSeconds(0.25f);
        mainCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
        monsterCamera.gameObject.SetActive(false);
    }

    private IEnumerator ActivatePlayerCamera()
    {
        yield return new WaitForSeconds(0.25f);
        playerCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        monsterCamera.gameObject.SetActive(false);
    }

    private IEnumerator ActivateMonsterCamera()
    {
        yield return new WaitForSeconds(0.25f);
        monsterCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(false);
    }

    public void OnMoneyPicked(int index)
    {
        player.transform.position = points[index].position;
        uiManager.AddNewYearPower();
    }

    public void OnDummyPicked()
    {
        uiManager.AddNewYearPower();
    }
}