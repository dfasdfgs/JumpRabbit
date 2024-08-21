using UnityEngine;

[CreateAssetMenu]
public class DataBaseManater : ScriptableObject
{
    public static DataBaseManater Instance;


    [Header("ÇÃ·¹ÀÌ¾î")]
    public float JumpPowerInc = 1;

    [Header("ÇÃ·¿Æû")]
    public Platform[] LargePlatformArr;
    [Tooltip("Å« ÇÃ·§Æû")]public Platform[] MiddlePlatformArr;
    [Tooltip("Áß°£ ÇÃ·§Æû")] public Platform[] smallPlatformArr;
    [Tooltip("ÀÛÀº ÇÃ·§Æû")] public PlatformManager.Data[] DataArr;

    [Tooltip("ÃÖ¼Ò°£°Ý")] public float GepIntervalMin = 1.5f;
    [Tooltip("ÃÖ´ë°£°Ý")] public float GepIntervalMax = 3.0f;

    [Header("Ä«¸Þ¶ó")] public float followSpeed;

    public void Init()
    {
        Instance = this;
    }
}
