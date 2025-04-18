using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBGMs
{
    TitleBGM,
    GameBGM,
}
    
public enum ESFXs
{
    SelectSFX,
    SignSFX,
    PaperSFX,
    CrowdSFX,
    GrowSFX,
    Cat1SFX,
    Cat2SFX,
    Cat3SFX,
    FailSFX,
    LoseSFX,
    WinSFX,
    LeverSFX,
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource _BGMAudio;
    [SerializeField] private AudioSource _SFXAudio;
    
    [SerializeField] private AudioClip[] _bgms;
    [SerializeField] private AudioClip[] _sfxs;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        else if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void PlayBGM(EBGMs bgm)
    {
        if (_BGMAudio.isPlaying && _BGMAudio.clip == _bgms[(int)bgm])
        {
            Debug.Log("이미 같은 BGM이 재생 중입니다. 재생 건너뜀.");
            return;
        }
        _BGMAudio.clip = _bgms[(int)bgm];
        _BGMAudio.Play();  
        _BGMAudio.loop = true;
    }

    public void StopBGM()
    {
        _BGMAudio.Stop();
    }

    public void PauseBGM()
    {
        if (!_BGMAudio.isPlaying)
        {
            return;
        }
        _BGMAudio.Pause();
    }

    public void PlaySFX(ESFXs sfx)
    {
        _SFXAudio.PlayOneShot(_sfxs[(int)sfx]);               
    }

    public void StopSFX()
    {
        _SFXAudio.Stop();
    }
}
