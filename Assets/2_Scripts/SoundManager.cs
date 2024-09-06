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
        DataBaseManager.SfxData sfxData = DataBaseManager.Instance.GetSfxAudioClip(sfxType);
        sfxAudioSource.volume = sfxData.volume;
        sfxAudioSource.PlayOneShot(sfxData.clip);
    }
    public void PlayBgm(Define.BgmType Type)
    {
        DataBaseManager.BgmData bgmData = DataBaseManager.Instance.GetBgmAudioClip(Type);
        bgmAudioSource.clip = bgmData.clip;
        bgmAudioSource.volume = bgmData.volume;
        bgmAudioSource.Play();
    }
}
