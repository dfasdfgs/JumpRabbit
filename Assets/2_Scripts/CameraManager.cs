using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    public void Init()
    {
        instance = this;
    }

    public void OnFollow(Vector2 targerPos)
    {
        StartCoroutine(OnFollowCor(targerPos));
    }
    private IEnumerator OnFollowCor(Vector2 targerPos)
    {
        while (0.1 < Vector3.Distance(transform.position, targerPos))
        {
            transform.position = Vector3.Lerp(transform.position, targerPos, Time.deltaTime * DataBaseManater.Instance.followSpeed);
            yield return null;
        }
    }
}
