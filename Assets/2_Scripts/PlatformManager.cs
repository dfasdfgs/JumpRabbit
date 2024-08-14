using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] Transform spawnPosTrf;

    [SerializeField] Platform[] LargePlatformArr;
    [SerializeField] Platform[] MiddlePlatformArr;
    [SerializeField] Platform[] smallPlatformArr;

    Dictionary<int, Platform[]> PlatformArrDic = new Dictionary<int, Platform[]>();


    internal void Init()
    {
        PlatformArrDic.Add(0, smallPlatformArr);
        PlatformArrDic.Add(1, MiddlePlatformArr);
        PlatformArrDic.Add(2, LargePlatformArr);
    }

    internal void Active()
    {
        Platform[] platforms = PlatformArrDic[2];

        int randID = Random.Range(0, platforms.Length);
        Platform randomplatform = platforms[randID];

        Platform platform = Instantiate(randomplatform);
        platform.Active(spawnPosTrf.position);
    }
}
