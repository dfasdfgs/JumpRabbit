using System.Collections.Generic;
using UnityEngine;
using static Define;

[CreateAssetMenu]
public class DataBaseManager : ScriptableObject
{
    public static DataBaseManager Instance;

    [Header("아이템")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBouns = 0.25f;

    [Header("연출")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;
    public Effect effect;

    [Header("플레이어")]
    public float JumpPowerInc = 1;
    public float GameOverY = -5f;

    [Header("플렛폼")]
    [Tooltip("큰 플랫폼")] public Platform[] LargePlatformArr;
    [Tooltip("중간 플랫폼")] public Platform[] MiddlePlatformArr;
    [Tooltip("작은 플랫폼")] public Platform[] smallPlatformArr;
    [Tooltip("플랫폼 배치")] public PlatformManager.Data[] DataArr;

    [Tooltip("최소간격")] public float GepIntervalMin = 1.5f;
    [Tooltip("최대간격")] public float GepIntervalMax = 3.0f;
    [Tooltip("보너스 추가 점수")] public float BonusValue;
    public int remainPlatformCount = 5;

    [Header("카메라")] public float followSpeed;

    [Header("사운드")]
    public SfxData[] sfxDataArr;
    public BgmData[] bgmDataArr;

    private Dictionary<Define.SfxType, SfxData> sfxDataDic;
    private Dictionary<Define.BgmType, BgmData> BgmDataDic;




    public void Init()
    {
        Instance = this;

        sfxDataDic = new Dictionary<SfxType, SfxData>();
        foreach (SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }

        BgmDataDic = new Dictionary<BgmType, BgmData>();
        foreach (BgmData data in bgmDataArr)
        {
            BgmDataDic.Add(data.bgmType, data);
        }
    }

    public SfxData GetSfxAudioClip(Define.SfxType type)
    {
        return sfxDataDic[type];
    }
    public BgmData GetBgmAudioClip(Define.BgmType type)
    {
        return BgmDataDic[type];
    }


    [System.Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1;
    }



    [System.Serializable]
    public class SfxData : SoundData
    {
        public Define.SfxType sfxType;
    }

    [System.Serializable]
    public class BgmData : SoundData
    {
        public Define.BgmType bgmType;
    }
}

