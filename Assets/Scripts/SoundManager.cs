using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip startSound;
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip money;
    [SerializeField] private AudioClip dummy;
    [SerializeField] private AudioClip lastMoney;
    [SerializeField] private AudioClip end;
    
    private AudioSource _audioSource;
    private static SoundManager _soundManager;
    public static SoundManager Instance => _soundManager;

    void Awake()
    {
        _soundManager = this;
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator PlayStartSound()
    {
        yield return new WaitForSeconds(0.25f);
        _audioSource.PlayOneShot(startSound);
    }

    public IEnumerator PlayBGM()
    {
        yield return new WaitForSeconds(0.75f);
        _audioSource.PlayOneShot(bgm);
    }

    public IEnumerator PlayEnd()
    {
        yield return null;
        _audioSource.Stop();
        _audioSource.PlayOneShot(end);
    }
    public void PlayMoney() => _audioSource.PlayOneShot(money);
    public void PlayDummy() => _audioSource.PlayOneShot(dummy);
    public void PlayLastMoney() => _audioSource.PlayOneShot(lastMoney);

    public IEnumerator Destroy()
    {
        yield return null;
        _audioSource.volume = 0f;
    }
}
