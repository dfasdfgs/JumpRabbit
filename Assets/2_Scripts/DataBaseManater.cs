using UnityEngine;

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

    [Header("�÷��̾�")]
    public float JumpPowerInc = 1;

    [Header("�÷���")]
    [Tooltip("ū �÷���")] public Platform[] LargePlatformArr;
    [Tooltip("�߰� �÷���")]public Platform[] MiddlePlatformArr;
    [Tooltip("���� �÷���")] public Platform[] smallPlatformArr;
    [Tooltip("�÷��� ��ġ")] public PlatformManager.Data[] DataArr;

    [Tooltip("�ּҰ���")] public float GepIntervalMin = 1.5f;
    [Tooltip("�ִ밣��")] public float GepIntervalMax = 3.0f;
    [Tooltip("���ʽ� �߰� ����")] public float BonusValue;

    [Header("ī�޶�")] public float followSpeed;

    public void Init()
    {
        Instance = this;
    }
}
