using UnityEngine;

[CreateAssetMenu]
public class DataBaseManater : ScriptableObject
{
    public static DataBaseManater Instance;


    [Header("�÷��̾�")]
    public float JumpPowerInc = 1;

    [Header("�÷���")]
    public Platform[] LargePlatformArr;
    [Tooltip("ū �÷���")]public Platform[] MiddlePlatformArr;
    [Tooltip("�߰� �÷���")] public Platform[] smallPlatformArr;
    [Tooltip("���� �÷���")] public PlatformManager.Data[] DataArr;

    [Tooltip("�ּҰ���")] public float GepIntervalMin = 1.5f;
    [Tooltip("�ִ밣��")] public float GepIntervalMax = 3.0f;

    [Header("ī�޶�")] public float followSpeed;

    public void Init()
    {
        Instance = this;
    }
}
