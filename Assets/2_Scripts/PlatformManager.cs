using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance;

    [System.Serializable]
    public class Data
    {
        [Tooltip("ÇÃÆÖÆû ±×·ì °¹¼ö")] public int GroupCount;
        [Tooltip("ÇÃÆÖÆû Å« ±×·ì ºñÀ²"), Range(0, 1f)][SerializeField] float LargePercent;
        [Tooltip("ÇÃÆÖÆû Áß°£ ±×·ì ºñÀ²"), Range(0, 1f)][SerializeField] float MiddlePercent;
        [Tooltip("ÇÃÆÖÆû ÀÛÀº ±×·ì ºñÀ²"), Range(0, 1f)][SerializeField] float SmallPercent;

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
    public int LandingPlatformNum;
    private Data lastData;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();


    internal void Init()
    {
        Instance = this;

        PlatformArrDic.Add(0, DataBaseManager.Instance.smallPlatformArr);
        PlatformArrDic.Add(1, DataBaseManager.Instance.MiddlePlatformArr);
        PlatformArrDic.Add(2, DataBaseManager.Instance.LargePlatformArr);
    }

    private void Update()
    {
        if (platformNumber - LandingPlatformNum < DataBaseManager.Instance.remainPlatformCount)
        {
            int lastIndex = DataBaseManager.Instance.DataArr.Length - 1;
            Data lastData = DataBaseManager.Instance.DataArr[lastIndex];

            int platformGroupSum = platformNumber + lastData.GroupCount;
            for (int i = 0; i < lastData.GroupCount; i++)
            {
                int platformID = lastData.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }

    internal void Active()
    {
        SpawnPos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataBaseManager.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;

            while (platformNumber < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                ActiveOne(platformID);
            }
        }
    }

    private void ActiveOne(int platformID)
    {
        platformNumber++;
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];

        Platform platform = Instantiate(randomplatform);

        if (platformNumber > 1)
            SpawnPos = SpawnPos + Vector3.right * platform.HalfSizeX;

        platform.Active(SpawnPos, platformNumber);

        float gap = Random.Range(DataBaseManager.Instance.GepIntervalMin, DataBaseManager.Instance.GepIntervalMax);
        SpawnPos = SpawnPos + Vector3.right * (platform.HalfSizeX + gap);
    }
}
