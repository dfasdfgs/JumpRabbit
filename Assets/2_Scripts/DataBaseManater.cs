using System.Collections.Generic;
using UnityEngine;
using static Define;

[CreateAssetMenu]
public class DataBaseManater : ScriptableObject
{
    public static DataBaseManater Instance;

    [Header("������")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBouns = 0.25f;

    [Header("����")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;
    public Effect effect;

    [Header("�÷��̾�")]
    public float JumpPowerInc = 1;

    [Header("�÷���")]
    [Tooltip("ū �÷���")] public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷���")] public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷���")] public Platform[] smallPlatformArr;
    [Tooltip("�÷��� ��ġ")] public PlatformManager.Data[] DataArr;

    [Tooltip("�ּҰ���")] public float GepIntervalMin = 1.5f;
    [Tooltip("�ִ밣��")] public float GepIntervalMax = 3.0f;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue;

    [Header("ī�޶�")] public float followSpeed;

    [Header("����")]
    public SfxData[] sfxDataArr;
    public BgmData[] bgmDataArr;

    private Dictionary<Define.SfxType, SfxData> sfxDataDic = new Dictionary<SfxType, SfxData>();
    private Dictionary<Define.BgmType, BgmData> BgmDataDic = new Dictionary<BgmType, BgmData>();




    public void Init()
    {
        Instance = this;

        foreach (SfxData data in sfxDataArr)
        {
            sfxDataDic.Add(data.sfxType, data);
        }

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

