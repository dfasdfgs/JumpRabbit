using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int GroupCount;
        [SerializeField] float LargePercent;
        [SerializeField] float MiddlePercent;
        [SerializeField] float SmallPercent;

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

    [SerializeField] Platform[] LargePlatformArr;
    [SerializeField] Platform[] MiddlePlatformArr;
    [SerializeField] Platform[] smallPlatformArr;
    [SerializeField] Data[] DataArr;
    private int platformNumber = 0;

    [SerializeField] float GepIntervalMin = 1.5f;
    [SerializeField] float GepIntervalMax = 3.0f;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();


    internal void Init()
    {
        PlatformArrDic.Add(0, smallPlatformArr);
        PlatformArrDic.Add(1, MiddlePlatformArr);
        PlatformArrDic.Add(2, LargePlatformArr);
    }

    internal void Active()
    {
        Vector3 Pos = spawnPosTrf.position;

        int platformGroupSum = 0;
        foreach (Data data in DataArr)
        {
            platformGroupSum += data.GroupCount;
            Debug.Log($"platformGroupSum: {platformGroupSum} ========");

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
        Debug.Log($"Active Pos :  {Pos}");

        if (platformNumber != 0)
            Pos = Pos + Vector3.right * platform.HalfSizeX;

        platform.Active(Pos);

        float gap = Random.Range(GepIntervalMin, GepIntervalMax);
        Pos = Pos + Vector3.right * (platform.HalfSizeX + gap);
        return Pos;
    }
}
