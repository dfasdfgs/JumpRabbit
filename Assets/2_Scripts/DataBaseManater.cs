using UnityEngine;

[CreateAssetMenu]
public class DataBaseManater : ScriptableObject
{
    public static DataBaseManater Instance;

    [Header("아이템")]
    public Item baseItem;
    public float itemSpawnPer = 0.2f;
    public float itemBouns = 0.25f;

    [Header("연출")]
    public Color ScoreColor;
    public Color BonusColor;
    public float ScorePopinterval = 0.2f;

    [Header("플레이어")]
    public float JumpPowerInc = 1;

    [Header("플렛폼")]
    [Tooltip("큰 플랫폼")] public Platform[] LargePlatformArr;
    [Tooltip("중간 플랫폼")]public Platform[] MiddlePlatformArr;
    [Tooltip("작은 플랫폼")] public Platform[] smallPlatformArr;
    [Tooltip("플랫폼 배치")] public PlatformManager.Data[] DataArr;

    [Tooltip("최소간격")] public float GepIntervalMin = 1.5f;
    [Tooltip("최대간격")] public float GepIntervalMax = 3.0f;
    [Tooltip("보너스 추가 점수")] public float BonusValue;

    [Header("카메라")] public float followSpeed;

    public void Init()
    {
        Instance = this;
    }
}
