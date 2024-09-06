using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource bgmAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;

    public void Init()
    {
        Instance = this;
    }

    public void PlaySfx(Define.SfxType sfxType)
    {
        DataBaseManater.SfxData sfxData = DataBaseManater.Instance.GetSfxAudioClip(sfxType);
        sfxAudioSource.volume = sfxData.volume;
        sfxAudioSource.PlayOneShot(sfxData.clip);
    }
    public void PlayBgm(Define.BgmType Type)
    {
        DataBaseManater.BgmData bgmData = DataBaseManater.Instance.GetBgmAudioClip(Type);
        bgmAudioSource.clip = bgmData.clip;
        bgmAudioSource.volume = bgmData.volume;
        bgmAudioSource.Play();
    }
}
