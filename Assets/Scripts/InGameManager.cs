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

    [SerializeField, Header("チュートリアルモンスター")] private GameObject tutorialMonster;
    
    [SerializeField, Header("インゲームモンスター")] private GameObject inGameMonster;

    [SerializeField, Header("エンドカメラ１")] private Camera endCamera1;
    
    [SerializeField, Header("エンドカメラ２")] private Camera endCamera2;
    
    [SerializeField, Header("エンドモンスター")] private Transform endMonster;

    [SerializeField, Header("神")] private Transform god;

    [SerializeField, Header("スモーク")] private GameObject smoke;

    [SerializeField, Header("最後のトレイル")] private Transform trail;

    [SerializeField, Header("江南ズ")] private GameObject gangNums;
    
    private static InGameManager _instance;
    public static InGameManager Instance => _instance;
    
    private AudioSource _audioSource;
    
    private MouseController _mouseController;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        if (!isSkipTutorial) StartCoroutine(StartScene());
        _audioSource = GetComponent<AudioSource>();
        _mouseController = GetComponent<MouseController>();
    }

    private IEnumerator StartScene()
    {
        yield return ActivatePlayerCamera();
        yield return new WaitForSeconds(0.5f);
        yield return uiManager.EnableDialogCanvas();
        yield return uiManager.DisableInGameCanvas();
        yield return uiManager.ShowMessage1();
        yield return uiManager.WaitMessageInterval();
        yield return ActivateMonsterCamera();
        yield return uiManager.ShowMessage2();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.ShowMessage3();
        yield return uiManager.WaitMessageInterval();
        yield return ActivatePlayerCamera();
        yield return uiManager.ShowMessage4();
        yield return SoundManager.Instance.PlayStartSound();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.DisableDialogCanvas();
        yield return ActivateMainCamera();
        yield return uiManager.EnableInGameCanvas();
        yield return SwitchMonster();
        yield return SoundManager.Instance.PlayBGM();
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

    private IEnumerator SwitchMonster()
    {
        yield return new WaitForSeconds(0.25f);
        tutorialMonster.gameObject.SetActive(false);
        inGameMonster.gameObject.SetActive(true);
    }

    public void OnMoneyPicked(int index)
    {
        player.transform.position = points[index].position;
        uiManager.AddNewYearPower();
        SoundManager.Instance.PlayMoney();
    }

    public void OnDummyPicked()
    {
        uiManager.AddNewYearPower();
        SoundManager.Instance.PlayDummy();
    }

    public void OnLastMoneyPicked()
    {
        SoundManager.Instance.PlayLastMoney();
        trail.SetParent(null);
        StartCoroutine(EndSceneCoroutine());
    }

    private IEnumerator EndSceneCoroutine()
    {
        mainCamera.gameObject.SetActive(false);
        endCamera1.gameObject.SetActive(true);
        _mouseController.enabled = false;
        Destroy(player.gameObject);
        yield return new WaitForSeconds(0.5f);
        yield return SoundManager.Instance.PlayEnd();
        yield return SwitchEndMonster();
        yield return uiManager.EnableDialogCanvas();
        yield return uiManager.DisableInGameCanvas();
        yield return uiManager.ShowMessage5();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.ShowMessage6();
        yield return uiManager.WaitMessageInterval();
        yield return InstantiateSmokeAndGod();
        yield return new WaitForSeconds(2f);
        yield return uiManager.ShowMessage7();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.ShowMessage8();
        yield return SoundManager.Instance.Destroy();
        yield return uiManager.WaitMessageInterval();
        yield return uiManager.DisableDialogCanvas();
        yield return SwitchEndCamera2();
        yield return PlayGangNumStyle();
    }
    
    private IEnumerator SwitchEndCamera2()
    {
        yield return new WaitForSeconds(0.25f);
        endCamera1.gameObject.SetActive(false);
        endCamera2.gameObject.SetActive(true);
    }

    private IEnumerator SwitchEndMonster()
    {
        yield return new WaitForSeconds(0.25f);
        endMonster.gameObject.SetActive(true);
    }

    private IEnumerator InstantiateSmokeAndGod()
    {
        yield return new WaitForSeconds(0.25f);
        endMonster.gameObject.SetActive(false);
        Instantiate(smoke, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        god.gameObject.SetActive(true);
    }

    private IEnumerator PlayGangNumStyle()
    {
        yield return new WaitForSeconds(0.25f);
        _audioSource.Play();
        gangNums.SetActive(true);
    }
}