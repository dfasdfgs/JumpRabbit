using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
         [Tooltip("ÇÃÆÖÆû ±×·ì °¹¼ö")] public int GroupCount;
        [Tooltip("ÇÃÆÖÆû Å« ±×·ì ºñÀ²"), Range(0, 1f)] [SerializeField] float LargePercent;
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
        Vector3 Pos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataBaseManater.Instance.DataArr)
        {
            platformGroupSum += data.GroupCount;

            while (platformNumber < platformGroupSum)
            {
                int platformID = data.GetPlatformID();
                Pos = ActiveOne(Pos, platformID);
                platformNumber++;
            }
        }
    }

    private Vector3 ActiveOne(Vector3 Pos, int platformID)
    {
        Platform[] platforms = PlatformArrDic[platformID];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];

        Platform platform = Instantiate(randomplatform);
        platform.Active(Pos);

        if (platformNumber != 0)
            Pos = Pos + Vector3.right * platform.HalfSizeX;

        platform.Active(Pos);

        float gap = Random.Range(DataBaseManater.Instance.GepIntervalMin, DataBaseManater.Instance.GepIntervalMax);
        Pos = Pos + Vector3.right * (platform.HalfSizeX + gap);
        return Pos;
    }
}
