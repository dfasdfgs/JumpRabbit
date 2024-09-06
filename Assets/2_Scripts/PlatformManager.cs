using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        [Tooltip("ÇÃÆÖÆû ±×·ì °¹¼ö")] public int GroupCount;
        [Tooltip("ÇÃÆÖÆû Å« ±×·ì ºñÀ²"), Range(0, 1f)][SerializeField] float LargePercent;
        [Tooltip("ÇÃÆÖÆû Áß°£ ±×·ì ºñÀ²"), Range(0, 1f)][SerializeField] float MiddlePercent;
        [Tooltip("ÇÃÆÖÆû ÀÛÀº ±×·ì ºñÀ²"), Range(0, 0.05f)][SerializeField] float SmallPercent;

        public int GetPlatformID()
        {
            float randVal = Random.value;
            int platformID;

            if (randVal <= LargePercent)
            {
                platformID = 2;
            }
            else if (randVal <= LargePercent + MiddlePercent)
            {
                platformID = 1;
            }
            else
            {
                platformID = 0;
            }

            return platformID;
        }
    }

    [SerializeField] Transform spawnPosTrf;
    Vector3 SpawnPos;

    private int platformNumber = 0;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();


    internal void Init()
    {
        PlatformArrDic.Add(0, DataBaseManater.Instance.smallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManater.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManater.Instance.LargePlatformArr);
    }

    internal void Active()
    {
        SpawnPos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataBaseManater.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;

            while (platformNumber < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                ActiveOne(platformID);
                platformNumber++;
            }
        }
    }

    private void ActiveOne(int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];

        Platform platform = Instantiate(randomplatform);

        bool isFirstFrame = platformNumber == 0;
        if (isFirstFrame == false)
            SpawnPos = SpawnPos + Vector3.right * platform.HalfSizeX;

        platform.Active(SpawnPos, isFirstFrame);

        float gap = Random.Range(DataBaseManater.Instance.GepIntervalMin, DataBaseManater.Instance.GepIntervalMax);
        SpawnPos = SpawnPos + Vector3.right * (platform.HalfSizeX + gap);
    }
}
